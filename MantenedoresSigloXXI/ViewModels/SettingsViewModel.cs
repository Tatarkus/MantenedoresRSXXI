﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Input;

using MantenedoresSigloXXI.Contracts.Services;
using MantenedoresSigloXXI.Contracts.ViewModels;
using MantenedoresSigloXXI.Helpers;
using MantenedoresSigloXXI.Models;

using Microsoft.Extensions.Options;

namespace MantenedoresSigloXXI.ViewModels
{
    // TODO WTS: Change the URL for your privacy policy in the appsettings.json file, currently set to https://YourPrivacyUrlGoesHere
    public class SettingsViewModel : Observable, INavigationAware
    {
        private readonly AppConfig _appConfig;
        private readonly IThemeSelectorService _themeSelectorService;
        private readonly ISystemService _systemService;
        private readonly IApplicationInfoService _applicationInfoService;
        private AppTheme _theme;
        private string _versionDescription;
        private ICommand _setThemeCommand;
        private ICommand _setLanguageCommand;
        private ICommand _privacyStatementCommand;


        public AppTheme Theme
        {
            get { return _theme; }
            set { Set(ref _theme, value); }
        }

        public string VersionDescription
        {
            get { return _versionDescription; }
            set { Set(ref _versionDescription, value); }
        }

        public ICommand SetThemeCommand => _setThemeCommand ?? (_setThemeCommand = new RelayCommand<string>(OnSetTheme));
        public ICommand SetLanguageCommand => _setLanguageCommand ?? (_setLanguageCommand = new RelayCommand<string>(OnSetLanguage));

        public ICommand PrivacyStatementCommand => _privacyStatementCommand ?? (_privacyStatementCommand = new RelayCommand(OnPrivacyStatement));

        public SettingsViewModel(IOptions<AppConfig> appConfig, IThemeSelectorService themeSelectorService, ISystemService systemService, IApplicationInfoService applicationInfoService)
        {
            _appConfig = appConfig.Value;
            _themeSelectorService = themeSelectorService;
            _systemService = systemService;
            _applicationInfoService = applicationInfoService;
        }

        public void OnNavigatedTo(object parameter)
        {
            VersionDescription = $"MantenedoresSigloXXI - {_applicationInfoService.GetVersion()}";
            Theme = _themeSelectorService.GetCurrentTheme();
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnSetTheme(string themeName)
        {
            var theme = (AppTheme)Enum.Parse(typeof(AppTheme), themeName);
            _themeSelectorService.SetTheme(theme);
        }

        private void OnSetLanguage(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language, false);
            CultureInfo.CurrentUICulture = new CultureInfo(language, false);
        }
        private void OnPrivacyStatement()
            => _systemService.OpenInWebBrowser(_appConfig.PrivacyStatement);
    }
}
