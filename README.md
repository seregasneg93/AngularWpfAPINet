# AngularWpfAPINet

в данном приложении есть ORM модель для работы с базой, Angular взаимодействует с api через SignalR2 так же через REST.
Wpf приложение взаимодействует с api через SignalR2.
Реализована логика отправки сообщения из Angular до api при помощи SignalR и на стороне Wpf это сообщение обрабатывается и отправялется ответ снова на Angular.
Принцип работы. на api поднимается сервер SignalR, сервер на Wpf для какой то работы, которая делает сбор данных и грузит в базу,
кленты на Angular. работы с базой у Angular сделана через REST + ORM + Linq.

AppLessons - фронтен ангуляра
KratekData - ORM
KratekServices - бизнес логика
KaretekWpf - приложение wpf
WebBackKratek - asp
