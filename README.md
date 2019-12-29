# UnityMagic

## 参考URL
- [Unity+.NET Core+MagicOnionの環境構築ハンズオン -Qiita-](https://qiita.com/_y_minami/items/c7899fdf1db505c06ba2)
- [MagicOnion v2を使ってUnity IL2CPPでgRPC通信をする -Qiita-](https://qiita.com/yKimisaki/items/1d55b08f3e7bcae46585)

## リポジトリに入りきらなかった
容量が大きすぎてpushしたら怒られたので下記のリポジトリに退避してある

(このリポジトリ単体でも実行できる(後述:と思ったらできなかった)、が自分でテストしたい際は該当URL参照)

- [UnityMagic-DownloadResources](https://github.com/kwtkMe/UnityMagic-DownloadResources)
  - gRPCだのMessagePackだのMagicOnionだの
  - そういうリソースのバージョンを固めて置いてある
  
上記を退避しても「./Client/Assets/Plugins/」と「./Client/Client/Libraries/」が重いと言われた(下記)のでやっぱり上記リポジトリからリソースを手動で入れるようにしてください

![怒られ1](https://user-images.githubusercontent.com/42050632/71555063-b5031700-2a6a-11ea-8057-5cf62b228f4f.png)
