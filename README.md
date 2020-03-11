# Dotnet.WinService
Exemplo de aplicação windows service

## Instalação
Via SC
```
sc create binPath = <PATH>\bin\Release\Dotnet.WinService.App.exe
```

Via InstallUtil.exe
```
installutil <PATH>\bin\Release\Dotnet.WinService.App.exe
```