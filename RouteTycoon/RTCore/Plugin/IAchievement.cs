namespace RouteTycoon.RTCore.Plugin
{
	public interface IAchievement
	{
		string Name { get; } //도전과제 이름
		string Description { get; } //도전과제 설명
		string Developer { get; } //도전과제 개발자
		bool isClear(); //클리어 했는지
		void Reward(); //보상 지급
	}
}
