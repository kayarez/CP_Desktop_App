   M S B A M L   `   `   `  ����B  >Rattler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Rattler.ViewsRattler.Views  5           Rattler.Views.TrainControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Rattler.Views     5      
�����_�.��5
      �   � ColumnDefinitions  5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��200��6   �� 5      $��70��6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��6'   .��5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TrainDataGrid��5   S   $��0��6   $��2��6#      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Тип поезда��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6f      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� 
 �� Path$

 Type� �� Mode$ TwoWay=�6�     5      $ Номер поезда��6%   $ * 6o    .  	 6;   �� $
 NumberTrain�$ TwoWay=�6�   5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6;   .+�5      �� -   5        $��	btnDelete��5      $��Удалить поезд��6>   $��	255 0 0 0q�6V   $��20(�6i   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   $��1��6;   .+�5       �� -   5        $��	btnUpdate��5       $+��%Редактировать поезд��6>   $��60 0 0 0q�6\   $��20(�6n   5!      �� 5"   
   $��0��6   $��2��6%   $��2��69   $��20q�6F   .+�5#      �� $��Тип поезда��6   $��	40 0 40 0q�6)   $��18(�6<   �� 5$      -   5        $��txtTrainType��5$      $��	40 0 40 0q�6*   $��20(�6>   �� 5%      $��Номер поезда��6   $��	40 0 40 0q�6+   $��18(�6?   �� 5&      -   5        $��txtNumberTrain��5&      $��	40 0 40 0q�6,   $��20(�6@   �� 5'      -   5        $��btnAdd��5'      $!��Добавить поезд��68   $��130 20q�6Q   $��20(�6b   5(      5)      5*      