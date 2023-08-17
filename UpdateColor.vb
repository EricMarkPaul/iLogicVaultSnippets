Dim colorValue As String
'Ask for user input for the color value they want
colorValue = InputBox("Please enter the correct color for this model", "Set Color")

'Get the full file path and file name
Dim filePath As String = ThisDoc.Document.FullFileName
'Capture the current workspace path
Dim workspacePath As String = ThisDoc.WorkspacePath

'Create the Vault path by removing the local machine Designs workspace with the Vault Designs workspace
Dim vaultFilePath As String = "$/Designs" & filePath.Substring(workspacePath.Length)

'Replace forward slashes with back slashes as this is what Vault is expecting
vaultFilePath = vaultFilePath.Replace("\", "/")

'Create list of parameters to update
Dim paramsToSet As New System.Collections.Generic.Dictionary(Of String, Object)
paramsToSet.Add("Color", colorValue)

Dim updateSuccess As Boolean
Try
	'Try to update the file properties in Vault
	updateSuccess = iLogicVault.UpdateVaultFileProperties(vaultFilePath, paramsToSet)
Catch ex As Exception
	Logger.Error("Error Updating file properties in Vault")
	MsgBox(ex.message)
End Try
'If the update wasn't successful, add a log note
If Not updateSuccess Then
	Logger.Error("Error Updating file properties in Vault")
End If
