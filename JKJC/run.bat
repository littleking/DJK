@echo Off

reg delete "HKEY_CURRENT_USER\Software\Microsoft\Office\12.0\Excel\Security" /v "AccessVBOM" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Office\12.0\Excel\Security" /v "AccessVBOM" /t REG_DWORD /d "00000001" /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Office\12.0\Excel\Security" /v "vbawarnings" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Office\12.0\Excel\Security" /v "vbawarnings" /t REG_DWORD /d "00000001" /f

reg delete "HKEY_CURRENT_USER\Software\Microsoft\Office\14.0\Excel\Security" /v "AccessVBOM" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Office\14.0\Excel\Security" /v "AccessVBOM" /t REG_DWORD /d "00000001" /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Office\14.0\Excel\Security" /v "vbawarnings" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Office\14.0\Excel\Security" /v "vbawarnings" /t REG_DWORD /d "00000001" /f

reg delete "HKEY_CURRENT_USER\Software\Microsoft\Office\15.0\Excel\Security" /v "AccessVBOM" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Office\15.0\Excel\Security" /v "AccessVBOM" /t REG_DWORD /d "00000001" /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Office\15.0\Excel\Security" /v "vbawarnings" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Office\15.0\Excel\Security" /v "vbawarnings" /t REG_DWORD /d "00000001" /f

Exit

