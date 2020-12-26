using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Caliburn.Light;
using NetDimension.NanUI.Logging;
using Xilium.CefGlue;

namespace NetDimension.NanUI
{


    public sealed class ChromiumEnvironmentBuilder
    {
        private string _libCefDir;
        private string _resourceDir;

        const string RESOURCE_DIR = "Resources";
        const string LOCALES_DIR = "locales";
        const string DEFAULT_FORMIUM_CEF_DIR = "fx";
        const string UP_LEVEL_DIR = "..";

        ExternalSubprocessConfiguration _externalSubprocessConfiguration = null;

        CefBinaryFilePathConfiguration _cefBinaryFilePaths = null;

        private Action<CefCommandLine> _cefCommandLineConfigurations;

        private Action<CefSettings> _cefSettingConfigurations;

        private Action<CefBrowserSettings> _cefCefBrowserSettingConfigurations;

        private List<Func<PlatformArchitecture, string>> _ifLibCefNotFound = new List<Func<PlatformArchitecture, string>>();

        private bool _forceHighDpiSupportDisabled;

        public SimpleContainer Container { get; }



        private readonly RuntimeBuilderContext _context;

        internal ChromiumEnvironmentBuilder(RuntimeBuilderContext runtimeBuilderContext)
        {
            _context = runtimeBuilderContext;

            Container = (SimpleContainer)_context.Properties[typeof(SimpleContainer)];

        }

        private void AutoDetectCefBinaryPath()
        {
            DetectLibCefFilesPath();
            DetectLibCefResourceFilesPath();
        }

        private bool EnsureLibCefExists(string path) => File.Exists(Path.Combine(path, "libcef.dll"));
        private bool EnsureLibCefResourceDirExists(string path) => Directory.Exists(path) && Directory.GetFiles(path, "*.pak", SearchOption.TopDirectoryOnly).Length > 0 && Directory.Exists(Path.Combine(path, "locales")) && Directory.GetFiles(Path.Combine(path, "locales"), "*.pak", SearchOption.TopDirectoryOnly).Length > 0;

        private string CheckLibCefPath(string path)
        {
            var searchPaths = new string[]
            {
                path,
                Path.Combine(path, WinFormium.PlatformArchitecture.ToString()),
                Path.Combine(path, DEFAULT_FORMIUM_CEF_DIR, WinFormium.PlatformArchitecture.ToString())
            };

            foreach (var dir in searchPaths)
            {
                if (EnsureLibCefExists(dir))
                {
                    return dir;
                }
            }

            return null;
        }

        private string CheckLibCefResourceFilesPath(string path)
        {
            var searchPaths = new string[]
            {
                path,
                Path.GetFullPath(Path.Combine(path, UP_LEVEL_DIR)),
                Path.GetFullPath(Path.Combine(path, UP_LEVEL_DIR, RESOURCE_DIR)),
                Path.Combine(path, RESOURCE_DIR)
            };

            foreach (var dir in searchPaths)
            {
                if (EnsureLibCefResourceDirExists(dir))
                {
                    return dir;
                }
            }

            return null;
        }

        private void DetectLibCefFilesPath()
        {
            var args = Environment.GetCommandLineArgs();

            var libCefPathArg = args?.FirstOrDefault(x => x.StartsWith("--libcef-dir-path"))?.Split('=');

            if (libCefPathArg != null && libCefPathArg.Length == 2 && EnsureLibCefExists(libCefPathArg[1]))
            {
                _libCefDir = libCefPathArg[1];
                return;
            }

            var searchPaths = new string[]
            {
                WinFormium.ApplicationRunningDirectory,
                Path.Combine(WinFormium.ApplicationRunningDirectory, WinFormium.PlatformArchitecture.ToString()),
                Path.Combine(WinFormium.ApplicationRunningDirectory, DEFAULT_FORMIUM_CEF_DIR, WinFormium.PlatformArchitecture.ToString()),
                Path.Combine(WinFormium.CommonCefRuntimeDirectory, WinFormium.PlatformArchitecture.ToString()),
            };

            foreach (var path in searchPaths)
            {
                if (EnsureLibCefExists(path))
                {
                    _libCefDir = path;
                    break;
                }
            }
        }


        private void DetectLibCefResourceFilesPath()
        {
            if (string.IsNullOrEmpty(_libCefDir))
                return;

            var searchPaths = new string[]
            {
                _libCefDir,
                Path.GetFullPath(Path.Combine(_libCefDir, UP_LEVEL_DIR)),
                Path.GetFullPath(Path.Combine(_libCefDir, UP_LEVEL_DIR, RESOURCE_DIR)),
                Path.Combine(_libCefDir, RESOURCE_DIR)
            };

            foreach (var path in searchPaths)
            {
                if (EnsureLibCefResourceDirExists(path))
                {
                    _resourceDir = path;
                    break;
                }
            }
        }

        public ChromiumEnvironmentBuilder IfLibCefNotFound(Func<PlatformArchitecture, string> libCefNotFoundHanlder)
        {
            _ifLibCefNotFound.Add(libCefNotFoundHanlder);

            return this;
        }

        public ChromiumEnvironmentBuilder ForceHighDpiSupportDisabled()
        {
            _forceHighDpiSupportDisabled = true;
            return this;
        }

        public ChromiumEnvironmentBuilder UseCustomCefBinaryPath(Action<CefBinaryFilePathConfiguration> useCustomCefBinaryPaths)
        {
            if (_cefBinaryFilePaths == null)
            {
                _cefBinaryFilePaths = new CefBinaryFilePathConfiguration();
            }

            useCustomCefBinaryPaths?.Invoke(_cefBinaryFilePaths);

            _libCefDir = CheckLibCefPath(_cefBinaryFilePaths.CefBinaryFileDirectory);
            _resourceDir = CheckLibCefResourceFilesPath(_cefBinaryFilePaths.CefBinaryFileDirectory);

            return this;
        }

        public ChromiumEnvironmentBuilder UseExternalSubprocess(Action<ExternalSubprocessConfiguration> useExternalSubprocessConfiguration)
        {
            if (_externalSubprocessConfiguration == null)
                _externalSubprocessConfiguration = new ExternalSubprocessConfiguration();

            useExternalSubprocessConfiguration?.Invoke(_externalSubprocessConfiguration);

            return this;
        }

        public ChromiumEnvironmentBuilder CustomCefCommandLineArguments(Action<CefCommandLine> configureCefCommandLineArguments)
        {
            if (configureCefCommandLineArguments != null)
            {
                _cefCommandLineConfigurations+=configureCefCommandLineArguments;
            }

            return this;
        }

        public ChromiumEnvironmentBuilder CustomCefSettings(Action<CefSettings> configureCefSettings)
        {
            if (configureCefSettings != null)
            {
                _cefSettingConfigurations+=configureCefSettings;
            }
            return this;
        }

        public ChromiumEnvironmentBuilder CustomDefaultBrowserSettings(Action<CefBrowserSettings> configureDefaultBrowserSettings)
        {
            if (configureDefaultBrowserSettings != null)
            {
                _cefCefBrowserSettingConfigurations+=configureDefaultBrowserSettings;
            }
            return this;
        }

        public ChromiumEnvironmentBuilder UseLogger<T>(ILogger logger = null) where T : ILogger
        {
            

            if (logger == null)
            {
                logger = (T)Activator.CreateInstance(typeof(T));
            }

            Container.RegisterInstance(logger);

            return this;
        }


        internal ChromiumEnvironment Build()
        {

            var env = new ChromiumEnvironment();

            

            if (_cefBinaryFilePaths == null)
            {
                AutoDetectCefBinaryPath();
            }

            if (string.IsNullOrEmpty(_libCefDir) || string.IsNullOrEmpty(_resourceDir))
            {

                foreach (var handle in _ifLibCefNotFound)
                {
                    var path = handle?.Invoke(WinFormium.PlatformArchitecture);

                    _libCefDir = CheckLibCefPath(path);
                    _resourceDir = CheckLibCefResourceFilesPath(path);

                    if(!string.IsNullOrEmpty(_libCefDir) && !string.IsNullOrEmpty(_resourceDir))
                    {
                        break;
                    }

                }

                if (string.IsNullOrEmpty(_libCefDir) || string.IsNullOrEmpty(_resourceDir))
                {
                    throw new DirectoryNotFoundException("The CEF binary files are not found.");
                }
            }

            env.LibCefDir = _libCefDir;
            env.LibCefResourceDir = _resourceDir;
            env.LibCefLocaleDir = Path.Combine(_resourceDir, LOCALES_DIR);

            if (_externalSubprocessConfiguration != null)
            {
                if (!File.Exists(_externalSubprocessConfiguration.SubprocessPath))
                {
                    throw new FileNotFoundException($"Can't find the path {_externalSubprocessConfiguration.SubprocessPath}.");
                }
                else
                {
                    env.SubprocessPath = _externalSubprocessConfiguration.SubprocessPath;
                }
            }



            env.CommandLineConfigurations = _cefCommandLineConfigurations;
            env.SettingConfigurations = _cefSettingConfigurations;
            env.CefBrowserSettingConfigurations = _cefCefBrowserSettingConfigurations;
            env.ForceHighDpiSupportDisabled = _forceHighDpiSupportDisabled;


            return env;
        }

    }

    public sealed class CefBinaryFilePathConfiguration
    {
        public PlatformArchitecture PlatformArchitecture => WinFormium.PlatformArchitecture;
        public string CurrentApplicationRunningDirectory => WinFormium.ApplicationRunningDirectory;
        public string CefBinaryFileDirectory { internal get; set; }
    }

    public sealed class ExternalSubprocessConfiguration
    {
        public PlatformArchitecture PlatformArchitecture => WinFormium.PlatformArchitecture;

        //private string DefaultSubprocessName => $"NetDimension.NanUI.Subprocess.{PlatformArchitecture}.exe";

        internal string SubprocessPath { get; private set; }

        public void UseCustomSubprocessPath(string subprocessPath)
        {
            if (File.Exists(subprocessPath))
            {
                SubprocessPath = subprocessPath;
                return;
            }

            throw new FileNotFoundException($"Can't find the path {subprocessPath}.");

        }

        //public void UseDefaultSubprocess()
        //{

        //    var searchPaths = new string[]
        //    {
        //        Path.Combine(WinFormium.ApplicationRunningDirectory,DefaultSubprocessName),
        //        Path.Combine(WinFormium.CommonCefRuntimeDirectory,DefaultSubprocessName)
        //    };

        //    foreach (var path in searchPaths)
        //    {
        //        if (File.Exists(path))
        //        {
        //            SubprocessPath = path;
        //            return;
        //        }
        //    }

        //    throw new FileNotFoundException($"Can't find the NetDimension.NanUI.Subprocess.${PlatformArchitecture}.exe in default paths.");

        //}
    }
}
