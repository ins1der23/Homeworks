# Первые шаги в гите

- чтобы работать в ~гите~ Git  нужно его скачать и установить
  > https://gitforwindows.org/
- работать с `Git` нужно в **терминале**

## Работа в терминале c Git

* git init  - инициализация репозитория
* git add - добавить файл в очередь коммита
* git commit -m "message text" - сделать коммит с текстом message text
* git log - весь журнал в неудобной форме
  
  > чтобы выйти нажать q
* git log --oneline - лог одной строкой
* git checkout 12a62fc - переход к указанному коммиту
* git checkout master - переход к главному коммиту
* после каждого изменения файла нужно заново его добавить и сделать коммит

## Создание репозитория

* создать папку для репозитория в **корне на диске C**- создать папку для репозитория в **корне на диске C**
* не использовать для файлов и папок *русские буквы, спец.символы и пробелы
* добавить созданную папку в vscode `File->Add Folder to Workspace`
* открыть созданную папку в терминале vscode `Right Click -> Open in Integrated Terminal`
* инициализировать репозиторий с помощью `git init`
* создать файл **.gitignore** в корне репозитория для неотслеживаемых файлов

## Commits

* для редактирования этого раздела создал отдельную ветку

## Branches

* Для совместной работы над проектами создаются ветви `git branch имя ветви`
* Над одним и тем файлом можно работать в нескольких ветвях
* Чтобы сменить ветвь `git checkout имя ветви`
* Когда ветвь, ответственная за какую-либо часть проекта готова, то можно делать ее слияние с master ветвью `git merge имя ветви` при этом нужно находится в master
* Если при слиянии ветвей один и тот же файл изменялся в разных ветвях по-разному, то возникнет конфликт, который необходимо разрешить, принимая изменения из ветви (incoming) или оставляя текущие (current)
* После успешного слияние старую ветвь можно удалить `git branch -d имя ветви`

