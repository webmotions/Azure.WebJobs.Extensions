Param (
	[Parameter(Mandatory=$true)]
	[string] $LatestCommitId
)

[Environment]::SetEnvironmentVariable("CommitHash", "$LatestCommitId", "User")