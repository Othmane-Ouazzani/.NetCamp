   M S B A M L   `   `   `  ����I  EMaterialDesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MaterialDesignMaterialDesign  5          MaterialDesign.validation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MaterialDesign     5      U QFilterDataGrid, Version=1.2.8.0, Culture=neutral, PublicKeyToken=42060d65a6cc17c24control&http://filterdatagrid.control.com/2021  5        N� Title$  
validation��5
      .��5      � .+�5   
   #  FilterDataGrid.FilterDataGrid  -   5          Name$ 
MyDataGrid��5   !   &   System.Windows.Controls.DataGrid   AutoGenerateColumns$ False��65    J� 	AllowDrop$ False��6Q   $��0,0,0,0q�6l   ��6}   �� *people+   Columns 5      '  !FilterDataGrid.DataGridTextColumn  5         IsColumnFiltered$
 True��6-   ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *Name+  5      $
 True��6-   $	 Age��6E    6R   �� *Age+  5      $
 True��6-   $ Email��6E    6T   �� *Email+  5      $
 True��6-   $ Address��6E    6V   �� *	Address+  5      $
 True��6-   $	 DOB��6E    6R   �� *DateOfBirth+  5      $
 True��6-   $ IsElligebale��6E    6[   �� *IsElligebale+5      5      5      