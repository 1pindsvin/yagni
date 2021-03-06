Imports System
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics
Imports System.Text.RegularExpressions


Public Module CodeTextTools

    Function AsVisualStudioMacroRegularExpression(ByVal expression As String)
        Return expression.Replace("\s", ":b").Replace("?", "@")
    End Function


    Sub FindInterfaceImplementors()
        If DTE.ActiveDocument.Selection Is Nothing Then
            Return
        End If
        Dim selection As TextSelection = DTE.ActiveDocument.Selection
        If selection.IsEmpty Then
            Return
        End If

        DTE.ExecuteCommand("Edit.Find")
        DTE.Find.FindWhat = "(class|interface):b+.@\:.*(:b|,)" + selection.Text + "(,|:b|\<|$)"
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentProject
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = True
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.FilesOfType = "*.cs"
        DTE.Find.Action = vsFindAction.vsFindActionFind
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
        DTE.Windows.Item("{CF2DDC32-8CAD-11D2-9302-005345000000}").Close()
    End Sub

    Sub FjernGaaseOejne()
        Const findStartGaaseOjne As String = "^\"""
        Const replaceWith As String = ""
        Const findEOL As String = "\"".*$"
        BuiltinRegexReplace(findStartGaaseOjne, replaceWith)
        BuiltinRegexReplace(findEOL, replaceWith)
    End Sub

    Sub InsertGaaseOejne()
        Const findTextLine As String = "^.+$"
        Const replaceWith As String = """\0"" + Environment.NewLine +"
        BuiltinRegexReplace(findTextLine, replaceWith)
    End Sub

    Sub RemoveVbCommentsFromCurrentDocument()
        Const commentPattern As String = "\'.*$"
        Const replaceWith As String = ""
        BuiltinRegexReplace(commentPattern, replaceWith)
    End Sub

    Sub RemoveCSharpRegionsFromCurrentDocument()
        Const commentPattern As String = "\#(region|endregion).*$"
        Const replaceWith As String = ""
        BuiltinRegexReplace(commentPattern, replaceWith)
    End Sub

    Private Sub BuiltInMakeOnTrackPropertiesTransient()
        Const foreignIDPattern As String = "^.*public.*:c+ID$"
        Const versionPattern As String = "^.*public System\.Data\.Linq\.Binary Version"
        Const replaceWith As String = "\t[Transient]\n\0"

        BuiltinRegexReplace(foreignIDPattern, replaceWith)
        BuiltinRegexReplace(versionPattern, replaceWith)

    End Sub

    Sub RemoveCSharpCommentsFromCurrentDocument()
        Const commentPattern As String = "\/\/.*$"
        Const replaceWith As String = ""
        BuiltinRegexReplace(commentPattern, replaceWith)
    End Sub

    Private Sub RegexReplace(ByVal pattern As String, ByVal replacer As MatchEvaluator)
        Dim myRegex As Regex = New Regex(pattern, RegexOptions.Multiline)
        DTE.ActiveDocument.Selection.SelectAll()
        Dim currentText As String = DTE.ActiveDocument.Selection.Text

        currentText = myRegex.Replace(currentText, replacer)
        DTE.ActiveDocument.Selection.Text = ""
        DTE.ActiveDocument.Selection.Insert(currentText)

    End Sub

    Sub SetVersionAndRefIDPropertiesInternal()
        SetVersionPropertiesInternal()
        SetRefIDropertiesInternal()
    End Sub


    Private Sub SetRefIDropertiesInternal()
        Const foreignIDPattern As String = "^.*public.*\s\w+?ID"
        Dim replacer As MatchEvaluator = Function(match) match.Value.Replace("public", "internal")
        RegexReplace(foreignIDPattern, replacer)
    End Sub

    Private Sub SetVersionPropertiesInternal()
        Const versionPattern As String = "public System\.Data\.Linq\.Binary Version"
        Const replaceWith As String = "internal System.Data.Linq.Binary Version"
        RegexReplace(versionPattern, replaceWith)
    End Sub

    Public Sub RemoveLinqChildRelations()
        Const entitySetPattern As String = "^.+EntitySet.+$"
        Const previousValuePattern As String = "previousValue\.\w+\.Remove\(this\);"
        Const setAddPattern As String = "value\..+\.Add\(this\)\;"
        Const replaceWith As String = ""
        RegexReplace(entitySetPattern, replaceWith)
        RegexReplace(previousValuePattern, replaceWith)
        RegexReplace(setAddPattern, replaceWith)
    End Sub

    Private Sub MakeOnTrackPropertiesTransient()
        Const foreignIDPattern As String = "^.*public.*\s\w+?ID"
        Const versionPattern As String = "^.*public System\.Data\.Linq\.Binary Version"
        Const replaceWith As String = vbTab & vbTab & "[Transient]" & vbNewLine & "$0"
        RegexReplace(foreignIDPattern, replaceWith)
        RegexReplace(versionPattern, replaceWith)

    End Sub

    Sub RegexReplace(ByVal searchPattern As String, ByVal replaceWith As String)

        DTE.ActiveDocument.Selection.SelectAll()

        Dim currentText As String = DTE.ActiveDocument.Selection.Text

        Dim myRegex As Regex = New Regex(searchPattern, RegexOptions.Multiline)
        currentText = myRegex.Replace(currentText, replaceWith)

        DTE.ActiveDocument.Selection.Text = ""
        DTE.ActiveDocument.Selection.Insert(currentText)

    End Sub

    Sub BuiltinRegexReplace(ByVal searchPattern As String, ByVal replaceWith As String)
        Dim findWhat As String = DTE.Find.FindWhat
        Dim findReplace As String = DTE.Find.ReplaceWith

        DTE.ActiveDocument.Selection.StartOfDocument()
        DTE.ExecuteCommand("Edit.Replace")
        DTE.ExecuteCommand("OtherContextMenus.ReplaceRegularExpressionBuilder.FindWhatText")
        DTE.ActiveDocument.Selection.StartOfDocument()
        DTE.Find.FindWhat = searchPattern
        DTE.Find.ReplaceWith = replaceWith
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = True
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If

        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.MatchWholeWord = True
        DTE.Find.MatchInHiddenText = True
        DTE.Find.MatchCase = True
        DTE.Find.FindWhat = findWhat
        DTE.Find.ReplaceWith = findReplace
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxWildcards

        DTE.Windows.Item("{CF2DDC32-8CAD-11D2-9302-005345000000}").Close()
    End Sub

End Module


