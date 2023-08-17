'This rule creates a new reel based off a chosen base asset, the new file will be given a file name based on Vault Numbering scheme
'Set the name of the numbering scheme or use 'Default' to use the pre-set scheme
Dim mNumSchmName As String = "Default"
'Optionally collect input values for file the selected numbering scheme; use the order of the fields as configured in the scheme;
Dim mNumInput As New System.Collections.Generic.List(Of String) 'add UDP.DisplayName, Value Pairs


'New File Path version 1, create a copy of the file in Vault, do a get and open the file live
'returns full file name in local working folder (download enforces override, if local file exists)
'returns "FileNotFound if file does not exist at indicated location
Dim fullFileName As String = iLogicVault.GetFileCopyBySourceFileNameAndAutoNumber("$/Designs/Workspaces/_Fishing Reel Assembly.iam", mNumSchmName, , True) 'optionally add the mNumInput variable; note - the CheckOut flag is an option also; default = True.
If fullFileName Is Nothing Then
	Logger.Error("File copy not created; check that the file can get found first." )
Else
	Logger.Info("File " & fullFileName & " created As copy.")
	ThisApplication.Documents.Open(fullFileName, True)
End If