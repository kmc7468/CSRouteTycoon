using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RouteTycoon.RTAPI
{
	/// <summary>
	/// 클래스, 구조체에 추가되는 확장 메서드들의 집합입니다.
	/// </summary>
	public static class Expansions
	{
		/// <summary>
		/// <see cref="Image"/>를 Base64 형식의 <see cref="String"/>으로 변환합니다.
		/// </summary>
		/// <param name="img">변환할 <see cref="Image"/>입니다.</param>
		/// <returns>변환된 <see cref="String"/>입니다.</returns>
		public static string ToBase64(this Image img)
		{
			return ToBase64(img, ImageFormat.Png);
		}

		/// <summary>
		/// <see cref="Image"/>를 Base64 형식의 <see cref="String"/>으로 변환합니다.
		/// </summary>
		/// <param name="img">변환할 <see cref="Image"/>입니다.</param>
		/// <param name="format">변환할 <see cref="Image"/>의 포맷입니다.</param>
		/// <returns>변환된 <see cref="String"/>입니다.</returns>
		public static string ToBase64(this Image img, ImageFormat format)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				img.Save(ms, format);
				byte[] b = ms.ToArray();

				string str = Convert.ToBase64String(b);
				return str;
			}
		}

		/// <summary>
		/// Base64 형식의 <see cref="String"/>을 <see cref="Image"/>로 변환합니다.
		/// </summary>
		/// <param name="str">변환할 <see cref="String"/>입니다.</param>
		/// <returns>변환된 <see cref="Image"/>입니다.</returns>
		public static Image ToImage(this string str)
		{
			byte[] b = Convert.FromBase64String(str);
			MemoryStream ms = new MemoryStream(b, 0, b.Length);

			ms.Write(b, 0, b.Length);
			Image img = Image.FromStream(ms, true);
			return img;
		}

		/// <summary>
		/// <see cref="String"/>을(를) RSA로 암호화합니다.
		/// </summary>
		/// <param name="str">암호화할 <see cref="String"/>입니다.</param>
		/// <param name="PublicKey">RSA로 암호화할 때 쓰이는 공개 키입니다.</param>
		/// <returns>암호화된 <see cref="String"/>입니다.</returns>
		public static string ToRSAStr(this string str, string PublicKey)
		{
			RSACryptoServiceProvider oEnc = new RSACryptoServiceProvider();

			oEnc.FromXmlString(PublicKey);

			return Convert.ToBase64String(oEnc.Encrypt(new UTF8Encoding().GetBytes(str), false));
		}

		/// <summary>
		/// RSA로 암호화된 <see cref="String"/>을(를) 복호화 합니다.
		/// </summary>
		/// <param name="str">복호화 할 <see cref="String"/>입니다.</param>
		/// <param name="PrivateKey">RSA를 복호화 할 때 쓰이는 보안 키입니다.</param>
		/// <returns>복호화 된 <see cref="String"/>입니다.</returns>
		public static string FromRSAStr(this string str, string PrivateKey)
		{
			RSACryptoServiceProvider oDec = new RSACryptoServiceProvider();

			oDec.FromXmlString(PrivateKey);

			return (new UTF8Encoding()).GetString(oDec.Decrypt(Convert.FromBase64String(str), false));
		}

		/// <summary>
		/// RSA 암호화 키(공개 키) 및 복호화 키(보안 키)를 만듭니다.
		/// </summary>
		/// <param name="rsa">삭제버튼 RSA와 관련된 기능을 제공하는 클래스입니다.</param>
		/// <returns>암호화 키(공개 키) 및 복호화 키(보안 키)가 담긴 <see cref="RSAKey"/> 구조체입니다.</returns>
		public static RSAKey GenRSAKey(this RSACryptoServiceProvider rsa)
		{
			RSAParameters privateKey = RSA.Create().ExportParameters(true);

			RSAParameters publicKey = new RSAParameters();
			publicKey.Modulus = privateKey.Modulus;
			publicKey.Exponent = privateKey.Exponent;

			RSAKey rsa_r = new RSAKey();

			{
				// Public

				RSACryptoServiceProvider r = new RSACryptoServiceProvider();
				r.ImportParameters(publicKey);
				rsa_r.Public = rsa.ToXmlString(false);
			}

			{
				// Private

				RSACryptoServiceProvider r = new RSACryptoServiceProvider();
				r.ImportParameters(privateKey);
				rsa_r.Private = rsa.ToXmlString(true);
			}

			return rsa_r;
		}

		/// <summary>
		/// 이 <see cref="Size"/>의 넓이를 제곱미터(평방미터) 단위로 구합니다.
		/// </summary>
		/// <param name="s">넓이를 구할 <see cref="Size"/>입니다.</param>
		/// <returns><see cref="Size"/>의 넓이입니다. (단위 : 제곱미터(평방미터))</returns>
		public static long ToSquareMeters(this Size s)
		{
			return s.Width * s.Height;
		}

		/// <summary>
		/// 이 <see cref="SizeF"/>의 넓이를 제곱미터(평방미터) 단위로 구합니다.
		/// </summary>
		/// <param name="sf">넓이를 구할 <see cref="SizeF"/>입니다.</param>
		/// <returns><see cref="SizeF"/>의 넓이입니다. (단위 : 제곱미터(평방미터))</returns>
		public static double ToSquareMeters(this SizeF sf)
		{
			return sf.Width * sf.Height;
		}

		/// <summary>
		/// 이 <see cref="PointF"/>를 <see cref="Point"/>로 바꿉니다.
		/// </summary>
		/// <param name="pf"><see cref="Point"/>로 바꿀 <see cref="PointF"/>입니다.</param>
		/// <returns>바뀐 <see cref="Point"/>입니다.</returns>
		public static Point ToPoint(this PointF pf)
		{
			return new Point((int)pf.X, (int)pf.Y);
		}

		/// <summary>
		/// 이 <see cref="RectangleF"/>를 <see cref="Rectangle"/>로 바꿉니다.
		/// </summary>
		/// <param name="rectf"><see cref="Rectangle"/>로 바꿀 <see cref="PointF"/>입니다.</param>
		/// <returns>바뀐 <see cref="Rectangle"/>입니다.</returns>
		public static Rectangle ToRectangle(this RectangleF rectf)
		{
			return new Rectangle(rectf.Location.ToPoint(), rectf.Size.ToSize());
		}
    }

	/// <summary>
	/// RSA 암호화 키(공개 키) 및 복호화 키(보안 키) 정보가 들어 있는 구조체입니다.
	/// </summary>
	public struct RSAKey
	{
		/// <summary>
		/// 암호화 키(공개 키)입니다.
		/// </summary>
		public string Public;
		/// <summary>
		/// 복호화 키(보안 키)입니다.
		/// </summary>
		public string Private;
	}
}
