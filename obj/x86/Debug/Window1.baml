   M S B A M L   `   `   `  ����G  CUpdateUIDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UpdateUIDemoUpdateUIDemo  5   	       UpdateUIDemo.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UpdateUIDemo     5   	     � Title$  Window1��5   	   $��645.366��6   $��1188.537��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ cityComboxBox��5
      $
��Left=�6+   $��
85,128,0,0q�6F   $	��Top=�6Z   $	��120��6r   6~   �� 5   
   -   5        $ communityComboxBox��5      $
��Left=�60   $��268,128,0,0q�6K   $	��Top=�6`   $	��120��6x   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��23��6>   $��117,271,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6�   $	��120��6�   ��6s   ��  �� Path$ Value� �� ElementName$ slider1��6�   �� 5   
   -   5         ��Name$ txbAge��5      $
��Left=�6$   $��299,278,0,0q�6?   $
��Wrap=�6T   $	��Top=�6i   ��6�   �� $	 Age� �� BindingGroupName$ binding���� 5   
   -   5         ��Name$ btnAge_1��5      	 � ToolTip$+	 %Click here and something will happen!��6#   $��Button��6S   $
��Left=�6d   $��379,279,0,0q�6   $	��Top=�6�   $��75��6�   6�   �� 5   
   -   5        
 ��Name$
 slider1��5   /   $��1��6   $��1��6   $
��Left=�6A    � Maximum$	 100Q�6]    � Minimum$ 0Q�6k   $��
72,235,0,0q�6y   $	��Top=�6�   $	��199��6�   �� 5   
   -   5        $ txtAge��5      $
��Left=�6"   $��23��6=   $��117,328,0,0q�6I   $
 Wrap=�6^   $��0��6s   $	��Top=�6}   $	��120��6�   .��6�   5      �� 5   
   -   5         ��Name$ 	listView1��5      $
��Left=�6&   $	��121��6A   $��
613,28,0,0q�6N   $	��Top=�6b   $	��340��6z    �� View 5      �� 5      .P�5      �� $��学号��6%    �� Width$ 60��61    �� DisplayMemberBinding 6<   �� *UserNo+�� 5      $��昵称��6%   $ 60��61    6<   �� *
UserName+�� 5      $��姓名��6%   $ 60��61    6<   �� *UserRealName+�� 5      $��邮箱��6%   $	 120��61    6=   �� *	UserEmail+5      5      �� 5&   
   $��10q�6   .+�5'      �� $
��Bold"�6   .��6&   Are you ready?66   	� 5(      .��5)      � .+�5+      �� $	��Yes��6    
��� � �6+   5,      5-      	� 5.      $	��0,5q�6   .��5/      � .+�51      �� $��No��6    
���  ��6*   52      53      	� 54       d� 	IsChecked$
 TrueY�6   .��55      � .+�57      �� $��Maybe��6    
�������6-   58      59      5:      5>      5?      