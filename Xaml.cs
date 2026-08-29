using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SDL_YONSEI_MANUAL
{
    public partial class MainWindow : Window
    {
        private List<string> currentImageList = new List<string>();
        private int currentImageIndex = 0;
        private double currentVideoAngle = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadModuleData("OVERVIEW");
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                LoadModuleData(btn.Tag.ToString());
            }
        }

        private void LoadModuleData(string category)
        {
            MediaMain.Stop();

            switch (category)
            {
                case "OVERVIEW":
                    TxtTitle.Text = "1. 장비 개요";
                    ShowVideo("sdl_overview.mp4", 0);
                    TxtDescription.Text = "■ 기구 설명\n" +
                                         "- 좌측 대차, 우측 쇼케이스로 구분\n" +
                                         "- 대차는 아래부터 1~16단\n" +
                                         "- 쇼케이스는 좌측 상단부터 1~4번\n\n" +
                                         "■ 동작 설명\n" +
                                         "- 대차의 초기 세팅은 16단 채우는 것으로 권장\n" +
                                         "- 오름차순으로 쇼케이스로 배식";
                    break;

                case "MOTION":
                    TxtTitle.Text = "2. 사용자 매뉴얼";
                    ShowImageList(new List<string> {
                        "pdf_page1.png", "pdf_page2.png", "pdf_page3.png", "pdf_page4.png", "pdf_page5.png",
                        "pdf_page6.png", "pdf_page7.png", "pdf_page8.png", "pdf_page9.png", "pdf_page10.png",
                        "pdf_page11.png", "pdf_page12.png", "pdf_page13.png", "pdf_page14.png"
                    });
                    TxtDescription.Text = "■ 사용자 전체 매뉴얼 가이드 (총 14페이지)\n\n" +
                                         "1~4p. 정상상태 동작절차, 비상상태 동작절차, 충돌 감지 복구절차\n" +
                                         "5~6p. 로봇 시스템 구성 및 시스템 준비\n" +
                                         "7~9p. 프로그램 활성화 진행 순서 및 메인 화면 버튼 기능\n" +
                                         "10~11p. 안전 관리 및 충돌 감지 동작 상세\n" +
                                         "12~14p. 전원 확인 및 로봇/대차/쇼케이스 청소 방법\n\n" +
                                         "※ 하단의 [◀ 이전] [다음 ▶] 버튼을 눌러 페이지를 순서대로 이동할 수 있습니다.";
                    break;

                case "SOFTWARE":
                    TxtTitle.Text = "3. 프로그램 사용법";
                    ShowImageList(new List<string> { "pdf_page1.png", "pdf_page2.png", "pdf_page3.png", "pdf_page4.png" });
                    TxtDescription.Text = "■ 소프트웨어 운용 및 절차 매뉴얼 (총 4페이지)\n" +
                                         "1~2p. 정상상태 동작절차 (시스템 초기화, 비밀번호 입력, 배식 시작/종료)\n" +
                                         "3p. 비상상태 동작절차 (비상정지 버튼 해제 및 재가동 순서)\n" +
                                         "4p. 충돌 감지 복구절차 (PFL 모드 충돌 알람 및 리셋 절차)\n\n" +
                                         "※ 화면 하단의 [◀ 이전] [다음 ▶] 버튼을 눌러 페이지를 이동할 수 있습니다.";
                    break;

                case "EMERGENCY":
                    TxtTitle.Text = "4. 비상정지 복구";
                    ShowVideo("sdl_emo.mp4", 90);
                    TxtDescription.Text = "■ 비상정지(EMO) 및 충돌 감지 복구 절차\n\n" +
                                         "■ 동작 안내\n" +
                                         "- 충돌상황 발생 시 로봇 시작 버튼 활성화 이후 배식시작 버튼 누르면 다시 정상작동됩니다.\n\n" +
                                         "[1. 비상정지 버튼 눌림 시]\n" +
                                         "- 비상정지 버튼을 시계 방향으로 돌려 해제\n" +
                                         "- 로봇 조작창에서 '충돌 리셋' → '배식 시작' 순으로 재가동\n\n" +
                                         "[2. 외부 충격으로 인한 충돌 감지 시 (PFL 모드)]\n" +
                                         "- PC 화면 '충돌 알람 발생' 팝업 확인\n" +
                                         "- 파란색으로 점등된 '충돌 리셋' 버튼 2회 클릭 후 '배식 시작'";
                    break;

                default:
                    break;
            }
        }

        private void ShowImageList(List<string> images)
        {
            VideoPanel.Visibility = Visibility.Collapsed;
            VideoControls.Visibility = Visibility.Collapsed;

            ImagePanel.Visibility = Visibility.Visible;
            ImageControls.Visibility = Visibility.Visible;

            currentImageList = images;
            currentImageIndex = 0;
            UpdateImageDisplay();
        }

        private void UpdateImageDisplay()
        {
            if (currentImageList == null || currentImageList.Count == 0) return;

            try
            {
                string fileName = currentImageList[currentImageIndex];
                ImgMain.Source = new BitmapImage(new Uri($"pack://application:,,,/{fileName}", UriKind.Absolute));
            }
            catch
            {
                ImgMain.Source = null;
            }

            TxtPageInfo.Text = $"{currentImageIndex + 1} / {currentImageList.Count}";
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageList.Count == 0) return;
            currentImageIndex = (currentImageIndex - 1 + currentImageList.Count) % currentImageList.Count;
            UpdateImageDisplay();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageList.Count == 0) return;
            currentImageIndex = (currentImageIndex + 1) % currentImageList.Count;
            UpdateImageDisplay();
        }

        private void ShowVideo(string fileName, double angle = 0)
        {
            ImagePanel.Visibility = Visibility.Collapsed;
            ImageControls.Visibility = Visibility.Collapsed;

            VideoPanel.Visibility = Visibility.Visible;
            VideoControls.Visibility = Visibility.Visible;

            currentVideoAngle = angle;
            VideoRotate.Angle = angle;

            AdjustVideoLayout();

            try
            {
                string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                MediaMain.Source = new Uri(videoPath, UriKind.RelativeOrAbsolute);
                MediaMain.Play();
            }
            catch
            {
            }
        }

        private void VideoPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustVideoLayout();
        }

        private void AdjustVideoLayout()
        {
            if (VideoPanel == null || MediaMain == null) return;

            double panelWidth = VideoPanel.ActualWidth;
            double panelHeight = VideoPanel.ActualHeight;

            if (panelWidth <= 0 || panelHeight <= 0) return;

            if (Math.Abs(currentVideoAngle - 90) < 1)
            {
                MediaMain.Width = panelHeight;
                MediaMain.Height = panelWidth;
            }
            else
            {
                MediaMain.Width = panelWidth;
                MediaMain.Height = panelHeight;
            }
        }

        private void MediaMain_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaMain.Position = TimeSpan.Zero; 
            MediaMain.Play();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e) => MediaMain.Play();
        private void BtnPause_Click(object sender, RoutedEventArgs e) => MediaMain.Pause();
        private void BtnStop_Click(object sender, RoutedEventArgs e) => MediaMain.Stop();
    }
}
