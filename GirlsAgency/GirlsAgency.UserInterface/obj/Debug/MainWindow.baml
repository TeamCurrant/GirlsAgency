   M S B A M L   `   `   `  ����  WpfApplication1     WpfApplication1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Currant Girls Agency��5   	   $	��350��6&   $��651.335��63   ���	#FF05836C � 
ResizeMode$ NoResize=�6p    � WindowStartupLocation$ CenterScreen=�6�   ��6Z   Z� .��5      � $��0,0,19,0q�6    � ColumnDefinitions 5   
   �� 5      $
��469* �6   �� 5      $
��106* �6   .+�5
   
   �� -   5         ��Name$ FilePathTextBox��5
      $
��Left=�6+   $��23��6F   $��	10,10,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��300��6�   {�.  .��6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 2Q�6      RenderingBias$ Quality=�6(   .��5      5      �� 5   
   -   5        $
��Open��5      $
��Left=�6    $��
325,10,0,0q�6;   $	��Top=�6O   $��80��6g   $��23��6�   �� 5   
   -   5        	 ��Name$	 uploadButton��5      $��Upload��6'   $
��Left=�68   $��	25,11,0,0q�6S   $	��Top=�6f   $��80��6~   {�.  $��1��6�   $��23��6�   �� 5   
   $��
Export PDF��6   $
��Left=�6&   $��	10,38,0,0q�6A   $	��Top=�6T   $	��100��6l   �� 5   
   $��
Export XML��6   $
��Left=�6&   $��
130,38,0,0q�6A   $	��Top=�6U   $	��100��6m   �� 5   
   $��Export Excel��6   $
��Left=�6(   $��
250,38,0,0q�6C   $	��Top=�6W   $	��100��6o   &   System.Windows.Controls.DataGrid  5   
   $
��Left=�6   $��	10,63,0,0q�6.   $	��Top=�6A   $	��246��6Y   $	��606��6f   $��2��6r   �� 5   
   $��Migrate��6   $
��Left=�6#   $��
367,38,0,0q�6>   $	��Top=�6R   $	��249��6j   ���	#FFE87D13
�������$��2��6�   �� 5   
   -   5        
 ��Name$
 comboBox��5      $
��Left=�6%   $��
410,11,0,0q�6@   $	��Top=�6T   $	��110��6l   $��2��6x    �� 
IsEditable .  �� 
IsReadOnly .  �� SelectedIndex$ 0��6�   .@�5      �� $��Girls��6   �� 5      $��	Customers��6   5      5      5      