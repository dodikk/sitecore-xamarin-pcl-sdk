
SET LAUNCH_DIR=%cd%

SET XAMARIN_PACKAGE_ROOT=%cd%
SET PACKAGE_UTILITY_EXE=%XAMARIN_PACKAGE_ROOT%\xamarin-component\xamarin-component.exe

cd ..
SET SCRIPTS_ROOT=%cd%

cd ..
SET REPOSITORY_ROOT=%cd%

cd .\deployment
SET DEPLOYMENT_DIR=%cd%

SET BINARIES_DIR=%DEPLOYMENT_DIR%\lib

::logs
echo "==========LOGS============"
echo %PACKAGE_UTILITY_EXE%
echo %XAMARIN_PACKAGE_ROOT%
echo %SCRIPTS_ROOT%
echo %REPOSITORY_ROOT%
echo %BINARIES_DIR%
echo "==========LOGS============"


:: And action
cd "%XAMARIN_PACKAGE_ROOT%"
echo %cd%

CALL %PACKAGE_UTILITY_EXE% create-manually Sitecore.MobileSDK.PCL-1.0.0.xam ^
		--name="Sitecore Mobile SDK PCL"                                                    ^
		--summary="Use content Sitecore CMS content in your native mobile apps in C#."      ^
		--publisher="Sitecore Corporation"                                                  ^
		--website="http://www.sitecore.net"                                                 ^
		--details="Details.md"                                                              ^
		--license="License.md"                                                              ^
		--getting-started="GettingStarted.md"                                               ^
		--icon="icons\Sitecore.MobileSDK.PCL_128x128.png"                                   ^
		--icon="icons\Sitecore.MobileSDK.PCL_512x512.png"                                   ^
																							^
		--library="ios":"%BINARIES_DIR%\Sitecore.MobileSDK.dll"                             ^
		--library="ios":"%BINARIES_DIR%\Microsoft.Threading.Tasks.Extensions.dll"           ^
		--library="ios":"%BINARIES_DIR%\Microsoft.Threading.Tasks.dll"                      ^
		--library="ios":"%BINARIES_DIR%\Newtonsoft.Json.dll"                                ^
		--library="ios":"%BINARIES_DIR%\System.Net.Http.Extensions.dll"                     ^
		--library="ios":"%BINARIES_DIR%\System.Net.Http.Primitives.dll"                     ^
		--library="ios":"%BINARIES_DIR%\System.Net.Http.dll"                                ^
		--library="ios":"%BINARIES_DIR%\System.Threading.Tasks.dll"                         ^
		--library="ios":"%BINARIES_DIR%\crypto.dll"                                         ^
		--library="ios":"%BINARIES_DIR%\System.IO.dll"                                      ^
																							^
		--library="android":"%BINARIES_DIR%\Sitecore.MobileSDK.dll"                         ^
		--library="android":"%BINARIES_DIR%\Microsoft.Threading.Tasks.Extensions.dll"       ^
		--library="android":"%BINARIES_DIR%\Microsoft.Threading.Tasks.dll"                  ^
		--library="android":"%BINARIES_DIR%\Newtonsoft.Json.dll"                            ^
		--library="android":"%BINARIES_DIR%\System.Net.Http.Extensions.dll"                 ^
		--library="android":"%BINARIES_DIR%\System.Net.Http.Primitives.dll"                 ^
		--library="android":"%BINARIES_DIR%\System.Net.Http.dll"                            ^
		--library="android":"%BINARIES_DIR%\System.Threading.Tasks.dll"                     ^
		--library="android":"%BINARIES_DIR%\crypto.dll"                                     ^
		--library="android":"%BINARIES_DIR%\System.IO.dll"                                  ^
																							^
		--library="winphone-7.1":"%BINARIES_DIR%\Sitecore.MobileSDK.dll"                    ^
		--library="winphone-7.1":"%BINARIES_DIR%\Microsoft.Threading.Tasks.Extensions.dll"  ^
		--library="winphone-7.1":"%BINARIES_DIR%\Microsoft.Threading.Tasks.dll"             ^
		--library="winphone-7.1":"%BINARIES_DIR%\Newtonsoft.Json.dll"                       ^
		--library="winphone-7.1":"%BINARIES_DIR%\System.Net.Http.Extensions.dll"            ^
		--library="winphone-7.1":"%BINARIES_DIR%\System.Net.Http.Primitives.dll"            ^
		--library="winphone-7.1":"%BINARIES_DIR%\System.Net.Http.dll"                       ^
		--library="winphone-7.1":"%BINARIES_DIR%\System.Threading.Tasks.dll"                ^
		--library="winphone-7.1":"%BINARIES_DIR%\crypto.dll"                                ^
		--library="winphone-7.1":"%BINARIES_DIR%\System.IO.dll"                             ^
																							^
		--sample="Sitecore Mobile SDK iOS Sample. Downloads a single item and shows an alert with its fields.":"../../test/LocalNugetTest/iMobileSdkDemo/iMobileSdkDemo.sln"


::Z:/Xamarin_Sdk_tfs/scripts/xamarin-store/xamarin-component/xamarin-component.exe     create-manually Sitecore.MobileSDK.PCL-1.0.0.xam                        --name="Sitecore Mobile SDK PCL"                                                             --summary="Use content Sitecore CMS content in your native mobile apps in C#."               --publisher="Sitecore Corporation"                                                           --website="http://www.sitecore.net"                                                          --details="Details.md"                                                                       --license="License.md"                                                                       --getting-started="GettingStarted.md"                                                        --icon="icons/Sitecore.MobileSDK.PCL_128x128.png"                                            --icon="icons/Sitecore.MobileSDK.PCL_512x512.png"                                                                                                                                         --library="ios":"../../deployment/lib/Sitecore.MobileSDK.dll"                                                 --library="ios":"../../deployment/lib/Microsoft.Threading.Tasks.Extensions.dll"                   --library="ios":"../../deployment/lib/Microsoft.Threading.Tasks.dll"                              --library="ios":"../../deployment/lib/Newtonsoft.Json.dll"                                        --library="ios":"../../deployment/lib/System.Net.Http.Extensions.dll"                             --library="ios":"../../deployment/lib/System.Net.Http.Primitives.dll"                             --library="ios":"../../deployment/lib/System.Net.Http.dll"                                        --library="ios":"../../deployment/lib/System.Threading.Tasks.dll"                                 --library="ios":"../../deployment/lib/crypto.dll"                                                 --library="ios":"../../deployment/lib/System.IO.dll"                                                                                                                                           --library="android":"../../deployment/lib/Sitecore.MobileSDK.dll"                                             --library="android":"../../deployment/lib/Microsoft.Threading.Tasks.Extensions.dll"               --library="android":"../../deployment/lib/Microsoft.Threading.Tasks.dll"                          --library="android":"../../deployment/lib/Newtonsoft.Json.dll"                                    --library="android":"../../deployment/lib/System.Net.Http.Extensions.dll"                         --library="android":"../../deployment/lib/System.Net.Http.Primitives.dll"                         --library="android":"../../deployment/lib/System.Net.Http.dll"                                    --library="android":"../../deployment/lib/System.Threading.Tasks.dll"                             --library="android":"../../deployment/lib/crypto.dll"                                             --library="android":"../../deployment/lib/System.IO.dll"                                                                                                                                       --library="winphone-7.1":"../../deployment/lib/Sitecore.MobileSDK.dll"                                        --library="winphone-7.1":"../../deployment/lib/Microsoft.Threading.Tasks.Extensions.dll"          --library="winphone-7.1":"../../deployment/lib/Microsoft.Threading.Tasks.dll"                     --library="winphone-7.1":"../../deployment/lib/Newtonsoft.Json.dll"                               --library="winphone-7.1":"../../deployment/lib/System.Net.Http.Extensions.dll"                    --library="winphone-7.1":"../../deployment/lib/System.Net.Http.Primitives.dll"                    --library="winphone-7.1":"../../deployment/lib/System.Net.Http.dll"                               --library="winphone-7.1":"../../deployment/lib/System.Threading.Tasks.dll"                        --library="winphone-7.1":"../../deployment/lib/crypto.dll"                                        --library="winphone-7.1":"../../deployment/lib/System.IO.dll"                                                                                                                                  --sample="Sitecore Mobile SDK iOS Sample. Downloads a single item and shows an alert with its fields.":"../../test/LocalNugetTest/iMobileSdkDemo/iMobileSdkDemo.sln"