Import-Module oh-my-posh 
Set-Theme Kenvix
$date = Get-Date
Clear-Host
Write-Output "Kenvix PowerShell Terminal Initialized at $date" ""

# Chocolatey profile
$ChocolateyProfile = "$env:ChocolateyInstall\helpers\chocolateyProfile.psm1"
if (Test-Path($ChocolateyProfile)) {
  Import-Module "$ChocolateyProfile"
}
