# 🤖 SDL(Side Dish Loader) 연세대학교 대면배식 로봇 매뉴얼

삼성웰스토리 연세대학교 사업장에 적용된 **Side Dish Loader(대면배식 로봇)** 장비의 운용, 소프트웨어 사용법 및 비상정지 복구 절차를 안내하기 위해 제작된 WPF 기반 키오스크형 매뉴얼 프로그램입니다.

인터넷 연결이 불가능한 현장 환경을 고려하여 **독립 실행형(Self-Contained Single EXE)** 으로 빌드 및 배포할 수 있도록 최적화되었습니다.

---
<div align="center"><h1>📚 STACKS</h1></div>

<div align="center">
<img src="https://img.shields.io/badge/python-3776AB?style=for-the-badge&logo=python&logoColor=white" />
<img src="https://img.shields.io/badge/C-A8B9CC?style=for-the-badge&logo=c&logoColor=white" />
<img src="https://img.shields.io/badge/C++-00599C?style=for-the-badge&logo=cplusplus&logoColor=white" />
<br>
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" />
<img src="https://img.shields.io/badge/java-007396?style=for-the-badge&logo=java&logoColor=white" />
<img src="https://img.shields.io/badge/html5-E34F26?style=for-the-badge&logo=html5&logoColor=white" />
</div>

## 📸 주요 기능 및 화면 구성

* **1. 작업 환경 (Work Environment):** C# 사용
* <img width="2557" height="1533" alt="image" src="https://github.com/user-attachments/assets/20b3efc4-79f2-4e03-8a79-51ce85191b24" />
 
* **2. 장비 개요 (Overview):** 로봇 기구부(대차, 쇼케이스) 구성 및 기본 배식 동작 메커니즘 안내 (비디오 매뉴얼)
* <img width="1726" height="1049" alt="image" src="https://github.com/user-attachments/assets/7d660a52-1782-461a-99f5-49a1f4ed93e2" />

* **3. 사용자 매뉴얼 (User Guide):** 매뉴얼 가이드 문서 탑재 (이미지 슬라이더 제어)
* <img width="1729" height="1049" alt="image" src="https://github.com/user-attachments/assets/4e6b7e37-8346-428f-9547-853bbfff0178" />

* **4. 프로그램 사용법 (Software Manual):** 소프트웨어 인터페이스 및 제어 프로세스 가이드
* <img width="1732" height="1053" alt="image" src="https://github.com/user-attachments/assets/a5fc8e9f-61f7-4d9b-8f19-6fb5f0a1d973" />

* **5. 비상정지 복구 (Emergency Recovery):** EMO 발생 및 PFL 충돌 감지 시 복구 절차 안내 (비디오 매뉴얼)
* <img width="1728" height="1055" alt="image" src="https://github.com/user-attachments/assets/6f3769ce-04c5-4ea4-8132-939de4a2e276" />


---

## 🛠 기술 스택 (Tech Stack)

* **Framework:** .NET 8.0 (WPF)
* **Language:** C#
* **Markup:** XAML
* **Deployment:** Self-Contained, Win-x64 Single File (.exe)

---

## 📁 주요 프로젝트 구조

```text
SDL_YONSEI_MANUAL/
├── App.xaml / App.xaml.cs            # 애플리케이션 시작 및 진입점
├── MainWindow.xaml                   # 대시보드 UI 레이아웃 및 스타일 정의
├── MainWindow.xaml.cs                # 미디어 제어 및 이벤트 핸들링 로직
├── sdl_overview.mp4                  # 장비 개요 시연 영상
└── sdl_emo.mp4                       # 비상정지 복구 가이드 영상
