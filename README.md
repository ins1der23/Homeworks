# Первые шаги в гите

- чтобы работать в ~гите~ Git  нужно его скачать и установить

  > https://gitforwindows.org/
  >
- работать с `Git` нужно в **терминале**

## Работа в терминале c Git

* git init  - инициализация репозитория
* git add - добавить файл в очередь коммита
* git commit -m "message text" - сделать коммит с текстом message text
* git log - весь журнал в неудобной форме

  > чтобы выйти нажать q
  >
* git log --oneline - лог одной строкой
* git checkout 12a62fc - переход к указанному коммиту
* git checkout master - переход к главному коммиту
* после каждого изменения файла нужно заново его добавить и сделать коммит

## Создание репозитория в vscode

* создать папку для репозитория в **корне на диске C**
* не использовать для файлов и папок *русские буквы, спец.символы и пробелы
* добавить созданную папку в vscode `File->Add Folder to Workspace`
* открыть созданную папку в терминале vscode `Right Click -> Open in Integrated Terminal`
* инициализировать репозиторий с помощью `git init`
* создать файл **.gitignore** в корне репозитория для неотслеживаемых файлов

## Commits

* Для фиксации изменений и возможности отката к прошлым версиям сущесвтуют коммиты
* для их создания нужно добавить файл в список отслеживаемых `git add имя файла` или `git add .` для всех файлов в папке
* после чего можно фикисровать текущее состояние `git commit -m "комментарий к коммиту"`
* для возврата к исходному состоянию коммита (отмены незафиксированных изменений) `git revert`
* для редактирования коментария к коммиту `git commit --amend`
* для просмотра истории коммитов `git log` или более удобно `git log --oneline`
* для перехода к указаному коммиту `git хеш коммита`
* для возврата к главному коммиту `git checkout master`
* для возврата к предыдущей версии и **удаления**последующих коммитов `git reset хеш коммита` к которому нужно возвратиться
* для возврата к предыдущей версии через отмену с сохранением отменяемых коммитов `git revert хеш коммита`

## Branches

* Для совместной работы над проектами создаются ветви `git branch имя ветви`
* Над одним и тем файлом можно работать в нескольких ветвях
* Чтобы сменить ветвь `git checkout имя ветви`
* Когда ветвь, ответственная за какую-либо часть проекта готова, то можно делать ее слияние с master ветвью `git merge имя ветви` при этом нужно находится в master
* Если при слиянии ветвей один и тот же файл изменялся в разных ветвях по-разному, то возникнет конфликт, который необходимо разрешить, принимая изменения из ветви (incoming) или оставляя текущие (current)
* После успешного слияние старую ветвь можно удалить `git branch -d имя ветви`