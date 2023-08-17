'This rule replaces the reel occurrence with the one selected in the ModelName user parameter
If Not ModelName = "" Then
	'Build one to many name/value pairs of Property/Value as search criteria
	Dim mSearchParams As New System.Collections.Generic.Dictionary(Of String, String) 'add UDP.DisplayName, Value Pairs
	mSearchParams.Add("File Name", ModelName)	'applies to file 001002.ipt
	'...add as many as required to enable a unique search result

	'returns full file name in local working folder (download enforces override, if local file exists)
	mVaultFile = iLogicVault.GetFileBySearchCriteria(mSearchParams, True, False)

	If mVaultFile Is Nothing Then
		Logger.Error("Vault file search: File not found - Please double check that file can be found with search criteria applied.")
	Else
		Logger.Info("File " & mVaultFile & " found by search and downloaded to local workspace.")
		Component.Replace("Reel Assembly", mVaultFile, False)
		Component.InventorComponent("Reel Assembly").SetDesignViewRepresentation("Default")
	End If
End If