# Welsotry_Yonsei_SDL_Project
<Window x:Class="SDL_YONSEI_MANUAL.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="SDL(Side Dish Loader) 대면배식 로봇 소개 프로그램" Height="850" Width="1400" MinHeight="700" MinWidth="1000" Background="#F0F2F5">

    <Window.Resources>
        <!-- 버튼 기본 스타일 -->
        <Style x:Key="MenuButtonStyle" TargetType="Button">
            <Setter Property="Background" Value="#FFFFFF"/>
            <Setter Property="Foreground" Value="#333333"/>
            <Setter Property="FontSize" Value="14"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
            <Setter Property="Height" Value="52"/>
            <Setter Property="Margin" Value="0,0,0,10"/>
            <Setter Property="Cursor" Value="Hand"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="Padding" Value="24,0"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border x:Name="border" Background="{TemplateBinding Background}" 
                                BorderBrush="#E5E7EB" BorderThickness="1" CornerRadius="8">
                            <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" VerticalAlignment="Center"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter TargetName="border" Property="Background" Value="#F3F4F6"/>
                                <Setter TargetName="border" Property="BorderBrush" Value="#004B93"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>

        <!-- 미디어 조작 버튼 스타일 -->
        <Style x:Key="MediaBtnStyle" TargetType="Button">
            <Setter Property="Background" Value="#FFFFFF"/>
            <Setter Property="Foreground" Value="#1F2937"/>
            <Setter Property="FontSize" Value="13"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="Height" Value="36"/>
            <Setter Property="Width" Value="90"/>
            <Setter Property="Margin" Value="4,0"/>
            <Setter Property="Cursor" Value="Hand"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border x:Name="border" Background="{TemplateBinding Background}" BorderBrush="#D1D5DB" BorderThickness="1" CornerRadius="6">
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter TargetName="border" Property="Background" Value="#E5E7EB"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="65"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <!-- 상단 헤더 -->
        <Border Grid.Row="0" Background="#004B93" Padding="25,0">
            <DockPanel VerticalAlignment="Center">
                <StackPanel Orientation="Horizontal" VerticalAlignment="Center">
                    <Border Background="#1E60A8" CornerRadius="4" Padding="8,4" Margin="0,0,12,0">
                        <TextBlock Text="삼성웰스토리" Foreground="#E0F2FE" FontSize="12" FontWeight="Bold"/>
                    </Border>
                    <TextBlock Text="연세대학교 SDL 로봇 장비 매뉴얼" Foreground="White" FontSize="19" FontWeight="Bold" VerticalAlignment="Center"/>
                </StackPanel>

                <StackPanel Orientation="Horizontal" HorizontalAlignment="Right" VerticalAlignment="Center">
                    <TextBlock Text="담당자 문의  |" Foreground="#93C5FD" FontSize="13" Margin="0,0,8,0" VerticalAlignment="Center"/>
                    <TextBlock Text="한국로보틱스 최성환 연구원 (010-4620-8838)" Foreground="White" FontSize="13" FontWeight="SemiBold" VerticalAlignment="Center"/>
                </StackPanel>
            </DockPanel>
        </Border>

        <!-- 메인 콘텐츠 영역 -->
        <Grid Grid.Row="1" Margin="20">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="240"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>

            <!-- 좌측: 모듈 선택 메뉴 -->
            <Border Grid.Column="0" Background="White" CornerRadius="12" Padding="16" Margin="0,0,16,0">
                <Border.Effect>
                    <DropShadowEffect BlurRadius="10" ShadowDepth="2" Direction="270" Color="#000000" Opacity="0.05"/>
                </Border.Effect>
                <StackPanel>
                    <TextBlock Text="NAVIGATION" FontSize="11" FontWeight="Bold" Foreground="#9CA3AF" Margin="4,4,0,12"/>

                    <Button Click="Menu_Click" Tag="OVERVIEW" Style="{StaticResource MenuButtonStyle}">
                        <TextBlock Text="1. 장비 개요" Margin="6,0,0,0"/>
                    </Button>

                    <Button Click="Menu_Click" Tag="MOTION" Style="{StaticResource MenuButtonStyle}">
                        <TextBlock Text="2. 사용자 매뉴얼" Margin="6,0,0,0"/>
                    </Button>

                    <Button Click="Menu_Click" Tag="SOFTWARE" Style="{StaticResource MenuButtonStyle}">
                        <TextBlock Text="3. 프로그램 사용법" Margin="6,0,0,0"/>
                    </Button>

                    <Button Click="Menu_Click" Tag="EMERGENCY" Style="{StaticResource MenuButtonStyle}">
                        <TextBlock Text="4. 비상정지 복구" Margin="6,0,0,0"/>
                    </Button>
                </StackPanel>
            </Border>

            <!-- 우측: 콘텐츠 영역 -->
            <Border Grid.Column="1" Background="White" CornerRadius="12" Padding="24">
                <Border.Effect>
                    <DropShadowEffect BlurRadius="10" ShadowDepth="2" Direction="270" Color="#000000" Opacity="0.05"/>
                </Border.Effect>

                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*"/>
                    </Grid.RowDefinitions>

                    <!-- 상단 제목 -->
                    <StackPanel Grid.Row="0" Margin="0,0,0,16">
                        <TextBlock x:Name="TxtTitle" Text="1. 장비 개요" FontSize="22" FontWeight="Bold" Foreground="#111827"/>
                        <Rectangle Height="2" Fill="#E5E7EB" Margin="0,12,0,0"/>
                    </StackPanel>

                    <!-- 하단 분할 영역 -->
                    <Grid Grid.Row="1">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="6.5*"/>
                            <ColumnDefinition Width="3.5*"/>
                        </Grid.ColumnDefinitions>

                        <!-- 좌측: 미디어 플레이어 영역 -->
                        <Border Grid.Column="0" Background="#111827" CornerRadius="10" Padding="12" Margin="0,0,16,0">
                            <Grid x:Name="MediaContainer">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="*"/>
                                    <RowDefinition Height="Auto"/>
                                </Grid.RowDefinitions>

                                <!-- 이미지 패널 -->
                                <Grid Grid.Row="0" x:Name="ImagePanel" Visibility="Collapsed">
                                    <Image x:Name="ImgMain" Stretch="Uniform" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"/>
                                </Grid>

                                <!-- 동영상 패널 -->
                                <Grid Grid.Row="0" x:Name="VideoPanel" Visibility="Visible" SizeChanged="VideoPanel_SizeChanged">
                                    <MediaElement x:Name="MediaMain" LoadedBehavior="Manual" UnloadedBehavior="Stop" Stretch="Uniform" MediaEnded="MediaMain_MediaEnded" HorizontalAlignment="Center" VerticalAlignment="Center">
                                        <MediaElement.RenderTransform>
                                            <TransformGroup>
                                                <RotateTransform x:Name="VideoRotate" Angle="0" CenterX="0.5" CenterY="0.5"/>
                                            </TransformGroup>
                                        </MediaElement.RenderTransform>
                                        <MediaElement.RenderTransformOrigin>
                                            <Point X="0.5" Y="0.5"/>
                                        </MediaElement.RenderTransformOrigin>
                                    </MediaElement>
                                </Grid>

                                <!-- 컨트롤 버튼 영역 -->
                                <StackPanel Grid.Row="1" Margin="0,12,0,4">
                                    <!-- 이미지 컨트롤 -->
                                    <StackPanel x:Name="ImageControls" Orientation="Horizontal" HorizontalAlignment="Center" Visibility="Collapsed">
                                        <Button Content="◀ 이전" Click="BtnPrev_Click" Style="{StaticResource MediaBtnStyle}"/>
                                        <TextBlock x:Name="TxtPageInfo" Text="1 / 1" VerticalAlignment="Center" Margin="16,0" FontWeight="Bold" FontSize="14" Foreground="White"/>
                                        <Button Content="다음 ▶" Click="BtnNext_Click" Style="{StaticResource MediaBtnStyle}"/>
                                    </StackPanel>

                                    <!-- 비디오 컨트롤 -->
                                    <StackPanel x:Name="VideoControls" Orientation="Horizontal" HorizontalAlignment="Center" Visibility="Visible">
                                        <Button Content="▶ 재생" Click="BtnPlay_Click" Style="{StaticResource MediaBtnStyle}"/>
                                        <Button Content="❚❚ 일시정지" Click="BtnPause_Click" Style="{StaticResource MediaBtnStyle}" Width="100"/>
                                        <Button Content="◼ 정지" Click="BtnStop_Click" Style="{StaticResource MediaBtnStyle}"/>
                                    </StackPanel>
                                </StackPanel>
                            </Grid>
                        </Border>

                        <!-- 우측: 상세 설명 영역 -->
                        <Border Grid.Column="1" Background="#F9FAFB" CornerRadius="10" Padding="20" BorderBrush="#E5E7EB" BorderThickness="1">
                            <ScrollViewer VerticalScrollBarVisibility="Auto">
                                <TextBlock x:Name="TxtDescription" Text="상세 설명 내용이 표시됩니다." FontSize="14" LineHeight="26" Foreground="#374151" TextWrapping="Wrap"/>
                            </ScrollViewer>
                        </Border>
                    </Grid>
                </Grid>
            </Border>
        </Grid>
    </Grid>
</Window>
