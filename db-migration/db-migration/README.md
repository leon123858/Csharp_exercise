# dbup Migration for mysql

## env

install `dbup` `dbup-mysql`

create `Scripts` folder

## 新增資料庫變設置變更

1. 在 `Script/*` 創建 XXX.sql 檔案
2. XXX.sql 內含創建/更新資料庫的腳本操作
3. 使用 visual studio 開啟專案
4. 右鍵設置 XXX.sql 屬性的 `建制動作` 為 `EmbeddedResource`
5. 利用 visual studio 建置與執行

## 跟進新版資料庫設置

1. 利用 visual studio 建置與執行

## 從頭構建資料庫

1. 利用 `mysql -u root -p` 登入 mysql
2. 利用 `CREATE DATABASE TodoList` 創建資料庫
3. 利用 visual studio 建置與執行
