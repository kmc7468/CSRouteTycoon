using System.Collections.Generic;
using System.Drawing;

namespace RouteTycoon.RTAPI
{
	/// <summary>
	/// RouteTycoon의 리소스와 관련된 기능을 제공합니다.
	/// </summary>
	public static class ResourceAPI
	{
		/// <summary>
		/// 사용할 만한 <see cref="Image"/>가 없을 때 사용되는 <see cref="Image"/>입니다. (설정된 리소스에 따라 달라집니다.)
		/// </summary>
		public static Image NoImage
		{
			get
			{
				return Image.FromStream(RTCore.ResourceManager.Get($".\\data\\res\\{RTCore.OptionManager.Get().ResFolder}\\images.npk", "img_no.png", 5, 7, 1, 6));
			}
		}

		/// <summary>
		/// RouteTycoon 리소스의 이미지가 담겨 있는 파일의 비밀번호를 암호화하여 반환합니다.
		/// </summary>
		public static string ResImageKey
		{
			get
			{
				return "5716".ToRSAStr("<RSAKeyValue><Modulus>4k1NwPQV+RKuN5Z1RIZYws45sOgeXOx5erQF2X+OVKJ4ilNBCzyoKupC1WPXLboR6oFeYDXC9hwVFCuZe0odzHkxZ1kg4JtOGipDkHV7tt2IItB6SARE3PJ6hc5PU7jw1B1w3FJqQJ3PeVkw/StAG/14oTePLcAa/bb+zaEB7GM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
			}
		}

		/// <summary>
		/// RouteTycoon 리소스의 소리가 담겨 있는 파일의 비밀번호를 암호화하여 반환합니다.
		/// </summary>
		public static string ResSoundKey
		{
			get
			{
				return "5716".ToRSAStr("<RSAKeyValue><Modulus>4k1NwPQV+RKuN5Z1RIZYws45sOgeXOx5erQF2X+OVKJ4ilNBCzyoKupC1WPXLboR6oFeYDXC9hwVFCuZe0odzHkxZ1kg4JtOGipDkHV7tt2IItB6SARE3PJ6hc5PU7jw1B1w3FJqQJ3PeVkw/StAG/14oTePLcAa/bb+zaEB7GM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
			}
		}

		/// <summary>
		/// RouteTycoon 리소스의 색 데이터들의 Key들을 모두 가져옵니다.
		/// </summary>
		public static List<string> ResColorKeys
		{
			get
			{
				List<string> k = new List<string>();

				foreach (var it in RTCore.ResourceManager._colors)
					k.Add(it.Key.ToString());

				return k;
			}
		}
	}
}
