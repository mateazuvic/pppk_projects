   M S B A M L   `   `   `  ????G  CFilesManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FilesManagerFilesManager  5   	       FilesManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FilesManager     5   	     ? WindowStartupLocation$  CenterScreen=?5   	    ? Title$ Remote file storage??5	   	   $	??450??6%   $	??800??62   .??5
      ?    MyBackground#??[  6   .+?5   
   ?? $??Choose Directory:??6   $
??Left=?6,   $??	76,34,0,0q?6G   $	??Top=?6Z   ?? 5   
   -   5         ??Name$ CbDirectories??5       ?? 
IsEditable . $
??Left=?6<   $??
197,34,0,0q?6W   $	??Top=?6k   $	??138??6?    J? RenderTransformOrigin$ 0.216,0.578&?6?   ?? 5   
   -   5         ??Name$ LbBlobs??5       ?? DisplayMemberPath$
 Name??6#   $
??Left=?6h   $	??263??6?   $??	76,74,0,0q?6?   $	??Top=?6?   $	??259??6?   ?? 5   
   -   5         ??Name$ 	BtnUpload??5      
????p??$??Upload??6>   $
??Left=?6P   $??
76,366,0,0q?6k   $	??Top=?6   $??75??6?   6?   ?? 5   
   -   5        $ 	BtnDelete??5      
????h{?$??Delete??6A   $
??Left=?6S   $??260,366,0,0q?6n   $	??Top=?6?   $??75??6?   6?   ?? 5   
   -   5        $ BtnDownload??5      
????iA?$??Download??6=   $
??Left=?6Q   $??168,366,0,0q?6l   $	??Top=?6?   $??75??6?   6?   ?? 5   
   $??Content type:??6   $
??Left=?6(   $??
389,73,0,0q?6C   $	??Top=?6W   ?? 5   
   $
??Left=?6G   $??23??6b   $??
503,73,0,0q?6n    ?? TextWrapping$
 Wrap=?6?   $	??Top=?6?   $	??204??6?   $??3q?6?   	 ?? 
IsReadOnly	 . ??6   ?? *Properties.ContentType+
 ?? Mode$
 OneWay=?6?   ?? 5   
   $??Content size:??6   $
??Left=?6(   $??389,132,0,0q?6C   $	??Top=?6X   ?? 5   
   $
??Left=?6J   $??23??6e   $??503,131,0,0q?6q   $
 Wrap=?6?   $	??Top=?6?   $	??204??6?   $??3q?6?   	 . ??6   ?? *Properties.ContentLength+$
 OneWay=?6?   ?? 5   
   $??Date Created:??6   $
??Left=?6(   $??389,190,0,0q?6C   $	??Top=?6X   ?? 5   
   $
??Left=?6F   $??23??6a   $??503,190,0,0q?6m   $
 Wrap=?6?   $	??Top=?6?   $	??204??6?   $??3q?6?   	 . ??6   ?? *Properties.CreatedOn+$
 OneWay=?6?   ?? 5   
   $??Last Modified:??6   $
??Left=?6)   $??389,250,0,0q?6D   $	??Top=?6Y   ?? 5   
   $
??Left=?6H   $??23??6c   $??503,250,0,0q?6o   $
 Wrap=?6?   $	??Top=?6?   $	??204??6?   $??3q?6?   	 . ??6   ?? *Properties.LastModified+$
 OneWay=?6?   ?? 5   
   $??Server encrypted:??6   $
??Left=?6,   $??389,302,0,0q?6G   $	??Top=?6\   ?? 5   
   $
??Left=?6K   $??23??6f   $??503,301,0,0q?6r   $
 Wrap=?6?   $	??Top=?6?   $??65??6?   $??3q?6?   	 . ??6   ?? *Properties.ServerEncrypted+$
 OneWay=?6?   5#      5$      