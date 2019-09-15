# C# RouteTycoon
[RouteTycoon](https://cafe.naver.com/routetycoon)은 철도 회사 운영 게임으로, 2015년에 처음으로 개발이 시작되었으며, 본 레포지토리에 업로드된 소스 코드는 2016년 5월 30일에 공개된 RouteTycoon 1.0.0 Beta 2 Preview 1 ServicePack 1의 소스 코드입니다. 일부 공개하기 어려운 소스 코드와 프로젝트는 제외하고 업로드했으며, 당시 프로그래밍 실력이 부족하던 때에 개발되어 코드가 많이 더러우니 이 점 양해해 주세요. 당시 개발되던 네트워크 모듈인 TMR의 소스 코드는 이미 예전에 [이곳](https://github.com/RouteTycoon)에 업로드를 해 두었으므로 TMR 및 관련 프로젝트의 소스 코드는 이 레포지토리에 업로드하지 않습니다.

C# RouteTycoon에는 많은 버그가 있으며, 완성되지 않은 기능도 있으나 추가 업데이트 계획은 없습니다.

## 사용 조건
- RouteTycoon의 소스 코드와 리소스의 저작권은 저를 포함한 C# RouteTycoon 개발팀에게 있으며, GPLv3에 의해 보호받습니다.
- RouteTycoon 에드온과 호환되는 게임을 만들거나, 또는 본 소스 코드의 일부를 사용 혹은 개선하여 새로운 게임을 만들 때 RouteTycoon이라는 이름을 사용하지 말아주세요.

## 컴파일 시 필요한 라이브러리
[npk](https://github.com/lqez/npk)가 필요합니다. 컴파일 후 헤더 파일은 `%NPK_DIRECTORY%/include` 디렉터리에, libnpk.lib 파일은 x86의 경우 `%NPK_DIRECTORY%/lib/Win32`, x64의 경우 `%NPK_DIRECTORY%/lib/x64` 디렉터리에 복사해 주세요. (NPK_DIRECTORY 환경 변수가 필요합니다.)

## 다운로드
- **소스 코드:** `git clone https://github.com/kmc7468/CSRouteTycoon.git`
- **바이너리:** https://www.dropbox.com/s/xb1ag0qvb6fc3ii/binary-opensource.zip?dl=0
- **리소스:** https://www.dropbox.com/s/bkruilvx539c0fo/data.zip?dl=0<br>
(압축을 풀지 마시고 data.zip 파일을 RouteTycoon.exe 파일과 같은 위치에 복사해 주세요.)