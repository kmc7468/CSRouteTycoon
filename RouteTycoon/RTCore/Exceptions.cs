using System;

namespace RouteTycoon.RTCore
{
	public class RouteTycoonException : Exception
	{
		
	}

	#region Map
	public class MapException : RouteTycoonException
	{

	}

	public class NotMapException : MapException
	{
		public override string Message
		{
			get
			{
				return "올바른 맵이 아닙니다.";
			}
		}
	}

	public class CanNotSupportVersionMapException : MapException
	{
		public override string Message
		{
			get
			{
				return "맵 버전이 지원 하지 않는 맵 버전 입니다.";
			}
		}
	}

	public class NoMapException : MapException
	{
		public override string Message
		{
			get
			{
				return "맵 파일을 찾을 수 없습니다.";
			}
		}
	}
	#endregion

	#region Sav
	public class SaveException : RouteTycoonException
	{

	}

	public class NotSaveException : SaveException
	{
		public override string Message
		{
			get
			{
				return "올바른 세이브 파일이 아닙니다.";
			}
		}
	}

	public class CanNotSupportVersionSaveException : SaveException
	{
		public override string Message
		{
			get
			{
				return "오래된 세이브 파일 입니다.";
			}
		}
	}
	#endregion

	#region Loaded
	public class LoadedException : RouteTycoonException
	{

	}

	public class NewsLoadedException : LoadedException
	{
		public override string Message
		{
			get
			{
				return "이 News 는 이미 로드 되었습니다.";
			}
		}
	}

	public class AchievementLoadedException : LoadedException
	{
		public override string Message
		{
			get
			{
				return "이 Achievement 는 이미 로드 되었습니다.";
			}
		}
	}
	#endregion

	#region Crash
	public class CrashException : RouteTycoonException
	{

	}

	public class NewsCrashException : CrashException
	{
		private string _crashname, _dev1, _dev2;

		public NewsCrashException(string crashname, string dev1, string dev2)
		{
			_crashname = crashname;
			_dev1 = dev1;
			_dev2 = dev2;
		}

		public override string Message
		{
			get
			{
				return $"{_dev1} 이(가) 개발한 {_crashname} 뉴스와 {_dev2} 이(가) 개발한 {_crashname} 뉴스의 이름이 서로 같아 충돌이 발생 하였습니다.";
			}
		}
	}

	public class AchievementCrashException : CrashException
	{
		private string _crashname, _dev1, _dev2;

		public AchievementCrashException(string crashname, string dev1, string dev2)
		{
			_crashname = crashname;
			_dev1 = dev1;
			_dev2 = dev2;
		}

		public override string Message
		{
			get
			{
				return $"{_dev1} 이(가) 개발한 {_crashname} 도전과제와 {_dev2} 이(가) 개발한 {_crashname} 도전과제의 이름이 서로 같아 충돌이 발생 하였습니다.";
			}
		}
	}

	public class UseCheatKeyException : CrashException
	{
		public override string Message
		{
			get
			{
				return "이미 사용 중인 치트 키 입니다.";
			}
		}
	}

	public class UseCommandKeyException : CrashException
	{
		public override string Message
		{
			get
			{
				return "이미 사용 중인 명령어 키 입니다.";
			}
		}
	}

	public class NotExistCheatKeyException : CrashException
	{
		public override string Message
		{
			get
			{
				return "존재 하지 않는 치트 키 입니다.";
			}
		}
	}

	public class NotExistCommandKeyException : CrashException
	{
		public override string Message
		{
			get
			{
				return "존재 하지 않는 명령어 키 입니다.";
			}
		}
	}
	#endregion

	#region Train
	public class TrainException : RouteTycoonException
	{

	}

	public class WrongLocomotiveException : TrainException
	{
		private string description = "";

		internal WrongLocomotiveException(string _description)
		{
			description = _description;
        }

		public override string Message
		{
			get
			{
				return $"올바르지 않은 기관차 파일 입니다. ({description})";
            }
		}
	}

	public class WrongCoachException : TrainException
	{
		private string description = "";

		internal WrongCoachException(string _description)
		{
			description = _description;
		}

		public override string Message
		{
			get
			{
				return $"올바르지 않은 객차 파일 입니다. ({description})";
			}
		}
	}

	public class WrongTrainDataException : TrainException
	{
		private string description = "";

		internal WrongTrainDataException(string _description)
		{
			description = _description;
		}

		public override string Message
		{
			get
			{
				return $"올바르지 않은 편성 파일 입니다. ({description})";
			}
		}
	}

	public class WrongEngineCoachException : TrainException
	{
		private string description = "";

		internal WrongEngineCoachException(string _description)
		{
			description = _description;
		}

		public override string Message
		{
			get
			{
				return $"올바르지 않은 편성 파일 입니다. ({description})";
			}
		}
	}
	#endregion

	#region etc
	public class UnabletoAccessPermission : RouteTycoonException
	{
		public override string Message
		{
			get
			{
				return "접근 권한이 없습니다.";
			}
		}
	}
	#endregion
}
