# TestTask_GardenGame

##Description:
### Fighting game Beat 'Em Up.

##Assets:  https://github.com/yusiart/AssetsForTest

## Plugins:

- UniTask -> https://github.com/Cysharp/UniTask
- UniRX -> https://github.com/neuecc/UniRx
- Zenject -> https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735
- OdinInspector -> NullRefException 
- DoTween -> https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676


##На момент 31.08.2024 в игре есть баг связаный с зачисткой волны врагов. Порой след волна не появляется. Следует создать отдельную сущность связанную с волнами врагов(Такой сейчас нету).
##На данный момент волны это всего лишь имитация. Game manager за каждые 3 убийства активирует след пачку врагов. 
##В идеале создать отдельную сущность которая создает волны врагов. 