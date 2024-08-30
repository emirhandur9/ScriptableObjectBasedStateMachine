# ScriptableObjectBasedStateMachine

Nasıl test edilir?

Assets/Scenes/SampleScene üzerinden test edebilirsiniz. Geyik idle state'inde başlayıp 3 saniye sonra yürümeye başlıyor. Player'ı görürse (WASD ile yürüyebilirsiniz) kaçmaya başlıyor ve sonra 10 saniye sonra idle state'ine geçip en başa dönüyor.

Nasıl kullanılır?

Yapay zekaya sahip olmasını istediğiniz objeye Agent scriptini ekleyin. Ardından Navmesh Agent ve animator ekleyin.
Ardından project kısmına sağ tıklayıp Create/AI/StateMachine ekleyin. Bu bizim ana yapay zeka kontrolcumuz olacak. Bunun üzerine State'leri ve transitionları ekleyip kullanabilirsiniz.
Ardından ihtiyaç duydukça, Create/AI States veya Create/AI Transitions ekleyebilirsiniz.