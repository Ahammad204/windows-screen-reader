(Add-Type -PassThru -Name ScreenReaderUtil -Namespace WinApiHelper -MemberDefinition @'
  const int SPIF_SENDCHANGE = 0x0002;
  const int SPI_SETSCREENREADER = 0x0047;

  [DllImport("user32", SetLastError = true, CharSet = CharSet.Unicode)]
  private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

  public static void EnableScreenReader(bool enable)
  {
    var ok = SystemParametersInfo(SPI_SETSCREENREADER, enable ? 1u : 0u, IntPtr.Zero, SPIF_SENDCHANGE);
    if (!ok)
    {
      throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
    }
  }
'@)::EnableScreenReader($false)