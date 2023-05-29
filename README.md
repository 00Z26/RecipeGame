# RecipeGame

## 结构
- Animation: 已有animation与animator
- GameData
  - DialogueData: NPC对话，自动对话，结算评语数据
  - PlayData: 食谱，NPC记录
- Prefabs
- PSB
- Resources: 资源目录
  - pic: 差分表情
  - ImpoortFont: 导入的字体源文件，根据教程制作字体Asset
- Scenes
- Script 
  - Dialogue
    - Data
      - ExcelSwapData: excel转换工具实例
- setting
- TextMeshPro
  - Resources:
    - Fonts & Materials: 字体的Asset文件存放
## 内部配置
1. Excel转换工具：保持Excel文件名与表名不变，复制粘贴待导入的表，保存。同级目录生成对应Asset，修改并保存到`GameData`对应位置
2. AutoDialogue: 修改场景Outside下`Auto`的子物体`AutoCheck`激活状态来开关开场的自动触发
3. 配置与NPC对话时，镜头的下移幅度：修改对应NPC物体的`Component <DialogueController>` 中`Y Move Dis`的值
4. 场景镜头移动限制：对应场景下Background物体的`Component <Background>`配置为当前场景下x最左/右的坐标，Y最上/下的坐标
1. 切换场景后player物体的位置：对应场景下Door的子物体`<Npcname>Door`中的脚本`SwapScene`,修改`PlayerToPos`为切换后在To场景的位置
5. Player镜头跟随设置：Persisent场景下`CameraSystem`,`MoveTime`为镜头的移动的延迟时间（0-1），`Delta Y Pos`为镜头垂直方向与player物体的距离
6. Player：`PlayerController`的基本参数
7. Cook场景：SumManager中`Component <SumManager>`的`Duration`为弹出高光结果图片前的等待时间，`Component <HightlightAnim>`中`HoldDuration`为高光结果保持的时间，时间过后弹出评价和结算
8. 在修改UI时最好保证上传时UI的初始激活状态不变
9. 运行时，如果中途退出运行状态，需注意复原 GameData-PlayData下`NpcData`中的`loop`和`ControllerIndex`(复原为0),`OpenDoorTimes`中总开门次数与本轮开门次数。
