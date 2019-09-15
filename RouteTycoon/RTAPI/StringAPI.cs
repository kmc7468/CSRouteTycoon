using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Moda.KString;

namespace RouteTycoon.RTAPI
{
	/// <summary>
	/// <see cref="String"/>및 <see cref="Char"/>와 관련된 기능들을 제공합니다.
	/// </summary>
	public static class StringAPI
	{
		private static readonly string HTable_ChoSung = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
		private static readonly string HTable_JungSung = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
		private static readonly string HTable_JongSung = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
		private static readonly ushort m_UniCodeHangulBase = 0xAC00;
		private static readonly ushort m_UniCodeHangulLast = 0xD79F;

		/// <summary>
		/// <see cref="List{T}"/>에서 특정 텍스트가 포함되어 있는 아이템을 가져옵니다.
		/// </summary>
		/// <param name="AllItem"><see cref="List{T}"/>입니다.</param>
		/// <param name="SearchText">포함될 텍스트입니다.</param>
		/// <param name="isUpperLowwerSensitive">영어에서 대소문자를 구분할지입니다.</param>
		/// <param name="ChosungJungsungSearch">한글에서 초성 또는 초성 및 중성까지만 입력해도 검색을 지원할지입니다.</param>
		/// <returns><see cref="List{T}"/>에서 특정 텍스트가 포함되어 있는 아이템들입니다.</returns>
		public static List<string> Search(List<string> AllItem, string SearchText, bool isUpperLowwerSensitive = false, bool ChosungJungsungSearch = true)
		{
			List<string> result = new List<string>();

			if (isUpperLowwerSensitive)
			{
				foreach (var it in AllItem)
					if (it.Contains(SearchText))
						result.Add(it);
			}
			else
			{
				foreach (var it in AllItem)
					if (it.ToLower().Contains(SearchText.ToLower()))
						result.Add(it);
			}

			if (ChosungJungsungSearch)
				foreach(var it in AllItem)
					if (it.KContains(SearchText))
						if (!result.Contains(it))
							result.Add(it);

			return result;
		}

		/// <summary>
		/// 배열에서 특정 텍스트가 포함되어 있는 아이템을 가져옵니다.
		/// </summary>
		/// <param name="AllItem">배열입니다.</param>
		/// <param name="SearchText">포함될 텍스트입니다.</param>
		/// <param name="isUpperLowwerSensitive">영어에서 대소문자를 구분할지입니다.</param>
		/// <param name="ChosungJungsungSearch">한글에서 초성 또는 초성 및 중성까지만 입력해도 검색을 지원할지입니다.</param>
		/// <returns>배열에서 특정 텍스트가 포함되어 있는 아이템들입니다.</returns>
		public static string[] Search(string[] AllItem, string SearchText, bool isUpperLowwerSensitive = false, bool ChosungJungsungSearch = true)
		{
			return Search(AllItem.ToList(), SearchText, isUpperLowwerSensitive, ChosungJungsungSearch).ToArray();
		}

		/// <summary>
		/// 글자에서 한글의 경우 초성으로 바꿉니다.
		/// </summary>
		/// <param name="str">초성을 가져올 글자입니다.</param>
		/// <returns>한글이 초성으로 바뀐 글자입니다.</returns>
		public static string GetChosung(string str)
		{
			return str.KExtractChosung();
		}

		/// <summary>
		/// 글자를 자소 분리합니다.
		/// </summary>
		/// <param name="str">자소 분리할 글자입니다.</param>
		/// <returns>자소 분리된 글자입니다.</returns>
		public static string GetSeparated(string str)
		{
			return str.KSeparate();
		}

		/// <summary>
		/// 초성, 중성, 종성을 한 글자로 합칩니다. (출처 : http://www.hoons.net/Board/asptip/Content/20889)
		/// </summary>
		/// <param name="choSung">초성입니다.</param>
		/// <param name="jungSung">중성입니다.</param>
		/// <param name="jongSung">종성입니다. (종성이 없다면 ' '로 하십시오.)</param>
		/// <returns>초성, 중성, 종성이 하나로 합쳐진 <see cref="Char"/>입니다.</returns>
		public static char MergeJaso(char choSung, char jungSung, char jongSung)
		{
			int ChoSungPos, JungSungPos, JongSungPos;
			int nUniCode;

			ChoSungPos = HTable_ChoSung.IndexOf(choSung);
			JungSungPos = HTable_JungSung.IndexOf(jungSung);
			JongSungPos = HTable_JongSung.IndexOf(jongSung);

			// 앞서 만들어 낸 계산식
			nUniCode = m_UniCodeHangulBase + (ChoSungPos * 21 + JungSungPos) * 28 + JongSungPos;

			// 코드값을 문자로 변환
			char temp = Convert.ToChar(nUniCode);

			return temp;
		}

		/// <summary>
		/// 이 글자가 한글인지 확인합니다.
		/// </summary>
		/// <param name="c">확인할 글자입니다.</param>
		/// <returns>한글인지 아닌 지입니다.</returns>
		public static bool isHangul(char c)
		{
			ushort temp = 0x0000;

			temp = Convert.ToUInt16(c);

			if ((temp < m_UniCodeHangulBase) || (temp > m_UniCodeHangulLast))
			{
				if (HTable_ChoSung.Trim().Contains(c)) return true;
				else if (HTable_JungSung.Trim().Contains(c)) return true;
				else if (HTable_JongSung.Trim().Contains(c)) return true;
				else return false;
			}
			else
				return true;
		}
	}

	/// <summary>
	/// 한글에 대한 정보를 담고 있습니다. (출처 : http://www.hoons.net/Board/asptip/Content/20889)
	/// </summary>
	public struct HANGUL_INFO
	{
		/// <summary>
		/// 한글인지 여부입니다.
		/// </summary>
		public bool isHangul;
		/// <summary>
		/// 원본 글자입니다.
		/// </summary>
		public char OriginalChar;
		/// <summary>
		/// 초성, 중성, 종성으로 분리된 한글입니다. (강 -> ㄱ, ㅏ, ㅇ)
		/// </summary>
		public char[] chars;
	}
}