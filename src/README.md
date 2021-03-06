# MyProgramableKeyboardServer
スマホやタブレットをキーボードとして使うためのツール

# 前提
このままでも使うことは出来ますが、ソースのカスタマイズを前提にしています。

# プログラムの実行に必要であると思われること
* 少なくともデバッグでの実行時には管理者権限が必要です(HttpListenerを動かすため)。
* ポートの開放(スマホ・タブレットからアクセスするため)

# 大雑把な仕組み
* 本アプリをウェブサーバーとして起動
* スマホ・タブレットからリクエストを送信
* リクエストパラメータに応じたキーを送信
上記の仕組みなので、キーの押しっぱなしには対応出来ていません。

# 修正箇所
修正(カスタマイズ)が必要になるであろう箇所は以下の通りです。

## KeyRequestWatcher.cs
### BaseUrl 
スマホ・タブレットからアクセスするさいのURL。好みの変更すれば良いかなと。

### GetValue(string body)
リクエストバラメータのキー = 送信するキー という前提で処理を書いていますが必要に応じて変更してもらえれば良いかなと。

## SendKeys.cs
### VirtualKey・_keyMapping
とりあえず、という感じで定義しているので必要応じて追加してもらえればと。修飾キーと組み合わせるのもありだと思います。

## Main.cs
### RequestWatcher_SendKeyEvent
今回はキー送信を前提とした実装になっていますが、ここでやりたいことを記述すれば良いと思います(名称的にキー送信関連の処理っぽいですが、実際はPOSTリクエスト受信時のコールバックなので、好きに変更すれば良いと思います)。

## SendKeys.cs/RemoteControlPage.htm
スマホ・タブレットに表示するキーと実際に送信するキーの組みあわせ。自分が使いやすいようにレイアウトを変更したりキーアサインを追加してもらえれば良いと思います。


# その他
今回はブラウザベースですが、要はポストリクエストを送信できれば良いだけなので専用アプリを作るのもありだと思います。


