## Hi there 👋

zipを展開するまえにプロパティのセキュリティの□にチェックを入れてください。
ソリューションを開いたら下記パッケージをアインストール、再インストールをしてください。
Aspose.Imaging
OpenCvSharp4.Windows
OpenCvSharp4.Extensions

下記　C:~capimgまでをshift + →で色を変えてかctrl + H を押してください。
右上にダイアログが出るので、下のテキストボックスにご自身のcapimgまでの絶対パスをコピペしてください。
ソリューション全体にして置換してください。
capimgフォルダをプロジェクトに作成してください。
256×256のjpgファイルを入れてください。
string ImgFilePath =
    $@"C:\Users\mizot\Desktop\VectorApp\VectorAngleHakarukunSecond\capimg\cap{exitImgFileNameIndex}.jpg";
    exitImgFileNameIndex = Int32.Parse(ImgfileNameChar[70].ToString());
    
char[] ImgfileNameChar = Imgfilename.ToCharArray();
string ImgFilePath =
    $@"C:\Users\mizot\Desktop\VectorApp\VectorAngleHakarukunSecond\capimg\cap{exitImgFileNameIndex}.jpg";
    exitImgFileNameIndex = Int32.Parse(ImgfileNameChar[XXXXX].ToString());
上記XXXXXのところには、cap{X}.jpgのXに該当するImgfileNameChar[]の配列番号を格納してください。
フォームは、デバックと100倍(120)倍スケールに変更しますのところを交互にやると正常に表示されます。
読みずらいので、READMEはダウンロード後のファイルでお読みください。

