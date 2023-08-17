'This rule creates a new reel based off a chosen base asset, the new file will be given a file name based on Vault Numbering scheme
'Set the name of the numbering scheme or use 'Default' to use the pre-set scheme
Dim mNumSchmName As String = "Default"
'Optionally collect input values for file the selected numbering scheme; use the order of the fields as configured in the scheme;
Dim mNumInput As New System.Collections.Generic.List(Of String) 'add UDP.DisplayName, Value Pairs


'New File Path version 2, create a local copy of the file and name that copy based on vault numbering scheme
Dim mFileNumber As String = iLogicVault.GetNewNumber(mNumSchmName) 'optionally add the mNumInput variable adding ...", mNumInput)

If mFileNumber Is Nothing Then
	Logger.Error("Number generation failed; check name (if not 'Default') or input parameters if required.")
Else
	'Build one to many name/value pairs of Property/Value as search criteria
	Dim mSearchParams As New System.Collections.Generic.Dictionary(Of String, String) 'add UDP.DisplayName, Value Pairs
	mSearchParams.Add("File Name", "_Fishing Reel Assembly.iam")
	'...add as many as required to enable a unique search result

	'returns full file name in local working folder (download enforces override, if local file exists)
	mVaultFile = iLogicVault.GetFileBySearchCriteria(mSearchParams, True, False)

	If mVaultFile Is Nothing Then
		Logger.Error("Vault file search: File not found - Please double check that file can be found with search criteria applied.")
	Else
		Logger.Info("File " & mVaultFile & " found by search and downloaded to local workspace.")
		
		Dim mLocalFileCopy As String = iLogicVault.CopyLocalFile(mVaultFile, mFileNumber)
		
		Logger.Info("File Number " & mFileNumber & " created and ready for consumption.")
		ThisApplication.Documents.Open(mLocalFileCopy)
	End If	
End If