'This rule trys to find an existing file based on search criteria, then add that file name to a user property "ModelName"
'Build one to many name/value pairs of Property/Value as search criteria;
Dim mSearchParams As New System.Collections.Generic.Dictionary(Of String, String) 'add UDP.DisplayName, Value Pairs
mSearchParams.Add("Color", Colors)
'...add as many as required to enable a unique search result

Dim mVaultFiles As List(Of String)
mVaultFiles = iLogicVault.CheckFilesExistBySearchCriteria(mSearchParams, False) 'returns file name(s)
If mVaultFiles.Count = 0 Then
	Logger.Error("The file(s) searched was(were) not found. Please double check that the search criteria's relevance.") 
	ModelName = ""
Else
	Dim mFileList As String
	For Each mFile As String In mVaultFiles
		mFileList += mFile & vbCr
	Next
	Logger.Info("iLogic-Vault file search found: " & mFileList)
	ModelName = mVaultFiles.FirstOrDefault
End If