Public Class Form1
    Public inventory As New List(Of Product)()
    Public Sub New()
        InitializeComponent()

        ' Initialize inventory
        inventory = New List(Of Product)()

        ' Example: Populate some products (optional)
        inventory.Add(New Product("Coke", "Soft Drink", 50, "Drinks"))
        inventory.Add(New Product("Toothpaste", "Dental Care", 20, "Personal Care"))
    End Sub
    Private Sub GenerateColumns()
        ' Clear any existing columns before adding new ones
        DataGridView1.Columns.Clear()

        ' Define the columns (name, header text, column type, etc.)
        Dim columnName As New DataGridViewTextBoxColumn()
        columnName.Name = "Name"
        columnName.HeaderText = "Product Name"
        columnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ' Fill available space
        DataGridView1.Columns.Add(columnName)

        Dim columnDescription As New DataGridViewTextBoxColumn()
        columnDescription.Name = "Description"
        columnDescription.HeaderText = "Description"
        columnDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ' Fill available space
        DataGridView1.Columns.Add(columnDescription)

        Dim columnQuantity As New DataGridViewTextBoxColumn()
        columnQuantity.Name = "Quantity"
        columnQuantity.HeaderText = "Quantity"
        columnQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Align numbers to the right
        columnQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells ' Adjust based on content width
        DataGridView1.Columns.Add(columnQuantity)

        Dim columnType As New DataGridViewTextBoxColumn()
        columnType.Name = "Type"
        columnType.HeaderText = "Type"
        columnType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Align numbers to the right
        columnType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells ' Adjust based on content width
        DataGridView1.Columns.Add(columnType)
    End Sub


    'Display the inventory to DGV
    Private Sub DisplayInventory()
        GenerateColumns()
        DataGridView1.Rows.Clear()
        For Each product As Product In inventory
            DataGridView1.Rows.Add(product.Name, product.Description, product.Price, product.Types)
        Next
    End Sub
    'Add Product to DGV
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim name As String = txtProductName.Text
        Dim description As String = TxtDesc.Text
        Dim price As Double = Double.Parse(txtPrice.Text)
        Dim types As String = CmbType.SelectedItem?.ToString()

        Dim newProduct As New Product(name, description, price, types)
        inventory.Add(newProduct)
        DisplayInventory()
    End Sub
    ''Clear all txt
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        txtProductName.Clear()
        TxtDesc.Clear()
        txtPrice.Clear()
    End Sub
    ''Update the DGV
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim rowIndex As Integer = DataGridView1.SelectedCells(0).RowIndex
            Dim selectedProduct As Product = inventory(rowIndex)

            selectedProduct.Name = txtProductName.Text
            selectedProduct.Description = TxtDesc.Text
            selectedProduct.Price = Decimal.Parse(txtPrice.Text)

            DisplayInventory()
        End If
    End Sub
    ''Delete Records
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim rowIndex As Integer = DataGridView1.SelectedCells(0).RowIndex
            inventory.RemoveAt(rowIndex)
            DisplayInventory()
        End If
    End Sub
End Class
