﻿Public Class FormFLMoptions
    Dim start As Boolean = True

    Dim fontIntestazioni As String = FormFLM.fontIntestazioni
    Dim fontIntestazioniSize As Single = FormFLM.fontIntestazioniSize
    Dim fontIntestazioniStyle As FontStyle = FormFLM.fontIntestazioniStyle
    Dim fontIntestazioniColor As String = FormFLM.fontIntestazioniColor

    Dim fontElementi As String = FormFLM.fontElementi
    Dim fontElementiSize As Single = FormFLM.fontElementiSize
    Dim fontElementiStyle As FontStyle = FormFLM.fontElementiStyle
    Dim fontElementiColor As String = FormFLM.fontElementiColor

    Dim fontFLM As String = FormFLM.fontFLM
    Dim fontFLMSize As Single = FormFLM.fontFLMSize
    Dim fontFLMStyle As FontStyle = FormFLM.fontFLMStyle
    Dim fontFLMColor As String = FormFLM.fontFLMColor

    Dim mouseTimeClick As Integer = FormFLM.Timer1.Interval

    Dim flmTips As Integer = FormFLM.flmTipsCheck

    Dim usoLayout As Integer

    Private Sub FormFLMoptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim carattere As Font

        usoLayout = FormFLM.flmLayout

        TextBoxPathFeel.Text = FormFLM.LabelPercorso.Text
        TextBoxPathFeel.Text = FormFLM.feelPath

        TextBoxPathGraphEditor.Text = FormFLM.grafxEditorPath

        carattere = New Font(fontIntestazioni, 8, fontIntestazioniStyle)

        TextBoxFontIntestazioni.Text = fontIntestazioni
        TextBoxFontIntestazioni.Font = carattere
        TextBoxFontIntestazioni.ForeColor = Color.FromName(fontIntestazioniColor)

        carattere = New Font(fontElementi, 8, fontElementiStyle)

        TextBoxFontElementi.Text = fontElementi
        TextBoxFontElementi.Font = carattere
        TextBoxFontElementi.ForeColor = Color.FromName(fontElementiColor)
        'TODO font FLM

        TextBoxMouseTimeClick.Text = mouseTimeClick

        If flmTips > 0 Then
            CheckBoxFLMTips.Checked = True
        Else
            CheckBoxFLMTips.Checked = False
        End If

        CheckBoxFLMBackgroundImage.Checked = FormFLM.flmBackgroundImageCheck

        Select Case usoLayout
            Case 1
                RadioButtonFLMLayout1.Checked = True
            Case 2
                RadioButtonFLMLayout2.Checked = True
            Case 3
                RadioButtonFLMLayout3.Checked = True
            Case Else
                MsgBox("Attenzione, valore di Layout nel file ini errato!! Verificare!")
        End Select

        PanelFLMLayout1.Enabled = RadioButtonFLMLayout1.Checked
        PanelFLMLayout2.Enabled = RadioButtonFLMLayout2.Checked
        PanelFLMLayout3.Enabled = RadioButtonFLMLayout3.Checked
    End Sub

    Private Sub TextBoxPathFeel_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxPathFeel.DoubleClick, TextBoxPathFeel.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBoxPathFeel.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub TextBoxPathGraphEditor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxPathGraphEditor.DoubleClick, TextBoxPathGraphEditor.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBoxPathGraphEditor.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub TextBoxFontIntestazioni_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxFontIntestazioni.DoubleClick,
                                                                                                TextBoxFontIntestazioni.Click

        Dim carattere As Font

        If FontDialog1.ShowDialog() = DialogResult.OK Then
            fontIntestazioni = FontDialog1.Font.Name
            fontIntestazioniSize = FontDialog1.Font.Size
            fontIntestazioniStyle = FontDialog1.Font.Style
            carattere = New Font(fontIntestazioni, 8, fontIntestazioniStyle)
            fontIntestazioniColor = FontDialog1.Color.Name

            TextBoxFontIntestazioni.ForeColor = FontDialog1.Color
            TextBoxFontIntestazioni.Font = carattere
            TextBoxFontIntestazioni.Text = fontIntestazioni
        End If
    End Sub

    Private Sub TextBoxFontIntestazioni_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxFontIntestazioni.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub TextBoxFontElementi_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxFontElementi.DoubleClick,
                                                                                            TextBoxFontElementi.Click

        Dim carattere As Font

        If FontDialog1.ShowDialog() = DialogResult.OK Then
            fontElementi = FontDialog1.Font.Name
            fontElementiSize = FontDialog1.Font.Size
            fontElementiStyle = FontDialog1.Font.Style
            carattere = New Font(fontElementi, 8, fontElementiStyle)
            fontElementiColor = FontDialog1.Color.Name

            TextBoxFontElementi.ForeColor = FontDialog1.Color
            TextBoxFontElementi.Font = carattere
            TextBoxFontElementi.Text = fontElementi
        End If
    End Sub

    Private Sub TextBoxFontElementi_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxFontElementi.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub TextBoxFontFLM_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxFontFLM.DoubleClick,
                                                                                        TextBoxFontFLM.Click

        Dim carattere As Font

        If FontDialog1.ShowDialog() = DialogResult.OK Then
            fontFLM = FontDialog1.Font.Name
            fontFLMSize = FontDialog1.Font.Size
            fontFLMStyle = FontDialog1.Font.Style
            carattere = New Font(fontFLM, 8, fontFLMStyle)
            fontFLMColor = FontDialog1.Color.Name

            TextBoxFontFLM.ForeColor = FontDialog1.Color
            TextBoxFontFLM.Font = carattere
            TextBoxFontFLM.Text = fontFLM
        End If
    End Sub

    Private Sub TextBoxFontFLM_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxFontFLM.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub TextBoxMouseTimeClick_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMouseTimeClick.TextChanged
        If Not start Then
            Try
                mouseTimeClick = Int(sender.text)
            Catch ex As Exception
                mouseTimeClick = FormFLM.Timer1.Interval
            End Try

            sender.text = mouseTimeClick
        Else
            start = False
        End If
    End Sub

    Private Sub RadioButtonFLMLayout1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout1.CheckedChanged
        usoLayout = 1
        PanelFLMLayout1.Enabled = RadioButtonFLMLayout1.Checked
    End Sub

    Private Sub RadioButtonFLMLayout2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout2.CheckedChanged
        usoLayout = 2
        PanelFLMLayout2.Enabled = RadioButtonFLMLayout2.Checked
    End Sub

    Private Sub RadioButtonFLMLayout3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout3.CheckedChanged
        usoLayout = 3
        PanelFLMLayout3.Enabled = RadioButtonFLMLayout3.Checked
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        FormFLM.LabelPercorso.Text = TextBoxPathFeel.Text
        FormFLM.feelPath = TextBoxPathFeel.Text

        FormFLM.grafxEditorPath = TextBoxPathGraphEditor.Text

        FormFLM.fontIntestazioni = fontIntestazioni
        FormFLM.fontIntestazioniSize = fontIntestazioniSize
        FormFLM.fontIntestazioniStyle = fontIntestazioniStyle
        FormFLM.fontIntestazioniColor = fontIntestazioniColor

        FormFLM.fontElementi = fontElementi
        FormFLM.fontElementiSize = fontElementiSize
        FormFLM.fontElementiStyle = fontElementiStyle
        FormFLM.fontElementiColor = fontElementiColor

        FormFLM.fontFLM = fontFLM
        FormFLM.fontFLMSize = fontFLMSize
        FormFLM.fontFLMStyle = fontFLMStyle
        FormFLM.fontFLMColor = fontFLMColor

        FormFLM.mouseTimeClick = mouseTimeClick
        FormFLM.Timer1.Interval = mouseTimeClick

        If (flmTips = 0) And CheckBoxFLMTips.Checked Then
            flmTips = 1
        End If

        If Not CheckBoxFLMTips.Checked Then
            flmTips = 0
        End If

        FormFLM.flmTipsCheck = flmTips

        FormFLM.flmBackgroundImageCheck = CheckBoxFLMBackgroundImage.Checked

        Select Case usoLayout
            Case 1
                FormFLM.flmLayout = 1
                FormFLM.flmBackgroundImage = My.Resources.Layout1Marquee
            Case 2
                FormFLM.flmLayout = 2
                FormFLM.flmBackgroundImage = My.Resources.Layout2Marquee
            Case 3
                FormFLM.flmLayout = 3
                FormFLM.flmBackgroundImage = My.Resources.Layout3Marquee
        End Select

        If CheckBoxFLMBackgroundImage.Checked Then
            FormFLM.BackgroundImage = ClassUtility.ChangeOpacity(FormFLM.flmBackgroundImage, 1)
        Else
            FormFLM.BackgroundImage = Nothing
        End If

        FormFLM.FormFLM_Resize()
        FormFLM.Refresh()

        If My.Computer.FileSystem.FileExists("FLM.ini") Then
            Try
                System.IO.File.Delete("FLM.ini")

                CreaFile()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            CreaFile()
        End If

        Dim usoFont As Font
        usoFont = New Font(fontIntestazioni, fontIntestazioniSize, fontIntestazioniStyle)
        FormFLM.GroupBoxObj.Font = usoFont
        FormFLM.GroupBoxObj.ForeColor = Color.FromName(fontIntestazioniColor)
        FormFLM.GroupBoxObj.Refresh()

        FormFLM.GroupBoxProprietà.Font = usoFont
        FormFLM.GroupBoxProprietà.ForeColor = Color.FromName(fontIntestazioniColor)
        FormFLM.GroupBoxProprietà.Refresh()

        usoFont = New Font(fontElementi, fontElementiSize, FontStyle.Regular)
        FormFLM.ListBoxObj.Font = usoFont
        FormFLM.ListBoxObj.Refresh()

        usoFont = New Font(fontFLM, fontFLMSize, FontStyle.Regular)
        FormFLM.LabelFeelLayoutManager.Font = usoFont
        FormFLM.LabelFeelLayoutManager.Refresh()

        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        TextBoxMouseTimeClick.Text = FormFLM.Timer1.Interval
        Me.Close()
    End Sub

    Private Sub CreaFile()
        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter("FLM.ini", True)

        file.WriteLine("File di configurazione del programma FLM F.E.(E.L.) Layout Manager by gothrek")
        file.WriteLine()
        file.WriteLine("non editare il file, le sue impostazioni vengono gestite direttamente dal programma.")
        file.WriteLine()
        file.WriteLine("feelPath=" & TextBoxPathFeel.Text)
        file.WriteLine("grafxEditorPath=" & TextBoxPathGraphEditor.Text)
        file.WriteLine("templateLayoutIni=" & TextBoxTemplateLayoutIni.Text)
        file.WriteLine("fontIntestazioniName=" & fontIntestazioni)
        file.WriteLine("fontIntestazioniSize=" & fontIntestazioniSize)
        file.WriteLine("fontIntestazioniStyle=" & fontIntestazioniStyle)
        file.WriteLine("fontIntestazioniColor=" & fontIntestazioniColor)
        file.WriteLine("fontElementiName=" & fontElementi)
        file.WriteLine("fontElementiSize=" & fontElementiSize)
        file.WriteLine("fontElementiStyle=" & fontElementiStyle)
        file.WriteLine("fontElementiColor=" & fontElementiColor)
        file.WriteLine("fontFLMName=" & fontFLM)
        file.WriteLine("fontFLMSize=" & fontFLMSize)
        file.WriteLine("fontFLMStyle=" & fontFLMStyle)
        file.WriteLine("fontFLMColor=" & fontFLMColor)
        file.WriteLine("mouseTimeClick=" & mouseTimeClick)

        If CheckBoxFLMTips.Checked Then
            file.WriteLine("flmTips=" & flmTips)
        Else
            file.WriteLine("flmTips=0")
        End If

        file.WriteLine("flmBackgroundImageCheck=" & CheckBoxFLMBackgroundImage.Checked)
        file.WriteLine("flmLayout=" & usoLayout)

        file.Close()
    End Sub

End Class