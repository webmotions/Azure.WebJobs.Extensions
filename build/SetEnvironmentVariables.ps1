Param (
	[Parameter(Mandatory=$true)]
	[string] $CommitHash,
	[Parameter(Mandatory=$true)]
	[string] $SourceBranch,
	[Parameter(Mandatory=$true)]
	[string] $BuildNumber
)

Write-Host "Setting CommitHash to $CommitHash"
Write-Host "##vso[task.setvariable variable=CommitHash]$CommitHash"

if ($SourceBranch -eq "refs/heads/dev") {
	$versionSuffix = "dev$($BuildNumber.Substring($BuildNumber.IndexOf("-")+1))"
	Write-Host "Setting versionSuffix to $versionSuffix"
	Write-Host "##vso[task.setvariable variable=VersionSuffix]-$versionSuffix"
}