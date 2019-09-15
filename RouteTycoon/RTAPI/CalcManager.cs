using System.Collections.Generic;
using System.Drawing;

namespace RouteTycoon.RTAPI
{
	/// <summary>
	/// RouteTycoon에서 사용된 계산식들을 제공합니다.
	/// </summary>
	public static class CalcManager
	{
		/// <summary>
		/// CustomList의 전체 페이지 수를 계산합니다.
		/// </summary>
		/// <param name="AllItemCount">List에 있는 모든 아이템 개수입니다.</param>
		/// <param name="PageItemCount">한 페이지에 들어가는 아이템 개수입니다.</param>
		/// <returns>계산된 페이지 수입니다.</returns>
		public static int CalcMaxListSize(int AllItemCount, int PageItemCount)
		{
			return RTCore.Environment.CalcPage(AllItemCount, PageItemCount);
		}

		/// <summary>
		/// CustomList의 전체 페이지 수를 계산합니다.
		/// </summary>
		/// <param name="lst">계산할 <see cref="System.Collections.Generic.List{T}"/> 입니다.</param>
		/// <param name="PageItemCount">한 페이지에 들어가는 아이템 개수입니다.</param>
		/// <returns>계산된 페이지 수입니다.</returns>
		public static int CalcMaxListSize(List<object> lst, int PageItemCount)
		{
			return RTCore.Environment.CalcPage(lst.Count, PageItemCount);
		}

		/// <summary>
		/// CustomList의 전체 페이지 수를 계산합니다.
		/// </summary>
		/// <param name="array">계산할 배열입니다.</param>
		/// <param name="PageItemCount">한 페이지에 들어가는 아이템 개수입니다.</param>
		/// <returns>계산된 페이지 수입니다.</returns>
		public static int CalcMaxListSize(object[] array, int PageItemCount)
		{
			return RTCore.Environment.CalcPage(array.Length, PageItemCount);
		}

		/// <summary>
		/// <see cref="Point"/>를 중심으로 한 영역을 계산합니다.
		/// </summary>
		/// <param name="p">중심 지점입니다.</param>
		/// <param name="s">계산할 크기입니다.</param>
		/// <returns><see cref="Point"/>를 중심으로 <see cref="Size"/>만큼의 영역을 그렸을 때 위치와 크기를 사각형으로 표현합니다.</returns>
		public static RectangleF CalcCenterRectangle(Point p, Size s)
		{
			return RTCore.Environment.CalcRectangle(p, s);
		}

		/// <summary>
		/// 글자의 크기를 계산합니다.
		/// </summary>
		/// <param name="s">계산할 글자입니다.</param>
		/// <param name="f">계산할 글자의 폰트입니다.</param>
		/// <returns>글자의 크기입니다.</returns>
		public static Size CalcStringSize(string s, Font f)
		{
			return RTCore.Environment.CalcStringSize(s, f);
		}
	}
}
