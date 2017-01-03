@echo off
echo.请输入当前发布的版本号，如：1.0.0
set /p push_version=
git add -A && git commit -m "Version %push_version%" && git push -u origin master
git tag -a %push_version% -m "By GitPush." && git push --tags