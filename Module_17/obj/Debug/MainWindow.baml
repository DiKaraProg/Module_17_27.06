   M S B A M L   `   `   `  ����D  @Module_17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Module_17	Module_17  5   	       Module_17.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Module_17     5   	     � Title$  
MainWindow��5   	   $	��443��6   $	��801��6)   .��5	      � $	��434��6   $��Bottom=�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   $��42��6*   �� 5      $
��195* �6   �� 5      $
��197* �6    � ColumnDefinitions 5   
   �� 5      $
��443* �6   �� 5      $
��357* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5      $��1��6%   
�������$��0��5   +      AutoGenerateColumns .  $��2��5   D   ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+  5      $ 
MiddleName��6%    69   �� *
MiddleName+  5      $ 	FirstName��6%    68   �� *	FirstName+  5      $ 
FatherName��6%    69   �� *
FatherName+  5      $ PhoneNumber��6%    6:   �� *PhoneNumber+  5      $ Email��6%    64   �� *Email+ � ContextMenu 5      �� 5       .@�5!      m� -   5        $��Добавить��5!      61   m� 5"      -   5        $��Удалить��5"      60   5#      5&        5'   
   -   5        $ DataGrid_Product��5(   ,   $��1��5'      $��1��6#    .  ��5(      ��  5)        5*      $ Id��6%    61   �� *Id+  5+      $ Email��6%    64   �� *Email+  5,      $ 	ProductId��6%    68   �� *	ProductId+  5-      $ ProdName��6%    67   �� *ProductName+ 5/      �� 50      .@�51      m� -   5        $��Добавить��51      61   m� 52      -   5        $��Удалить��52      60   53      55      57      58      