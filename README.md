
# 五張撲克牌

## 專案簡介

本專案為 Visual C# 桌面應用程式，是一個五張撲克牌遊戲，提供自動發牌、換牌以及牌型判斷功能。玩家可以設定押注金額，系統會根據不同的牌型賠率進行計算，幫助玩家計算賭注結果。

## 開發環境

- 語言：Visual C#
- IDE：Visual Studio 2026
- 作業系統：Windows
- 專案型態：Windows Forms Application

## 功能需求

### 輸入資訊

| 項目       | 型別/模式   | 單位        | 預設值   | 範圍說明     |
|------------|-------------|-------------|----------|--------------|
| 總資金     | 整數        | 新台幣(NT$) | 1,000,000|              |
| 押注金額   | 整數        | 新台幣(NT$) | 0        | 0 ~ 總資金額 |


### 輸出規則

- 總資金：金額輸出格式以千分位逗號
  
- 輸出牌型：如2一對、A三條…等
    

### UI畫面設計

- 主畫面包含牌桌、下注、功能及訊息顯示區。
- 牌桌區：用來顯示玩家的五張撲克牌
- 下注區：用來顯示玩家的賭注，玩家可以在這個區域設定下注金額
- 功能區：提供發牌、換牌及判斷牌型功能
- 訊息顯示區：顯示遊戲過程的相關訊息及狀態

  ![輸出](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/ui.png)


## 計算說明

### 賠率

| 牌型       | 賠率 |     範例           |
|------------|------|--------------------|
| 皇家同花順 |  250 | ![皇家同花順](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/q.png) |
| 同花順     |   50 | ![同花順](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/w.png) |
| 四條       |   25 | ![四條](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/r.png) |
| 葫蘆       |    9 | ![葫蘆](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/t.png) |
| 同花       |    6 | ![同花](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/e.png) |
| 順子       |    4 | ![順子](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/a.png) |
| 三條       |    3 | ![三條](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/y.png) |
| 兩對       |    2 | ![兩對](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/s.png) |
| 一對       |    1 | ![一對](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/d.png) |


## 檢核、防呆及提示機制

### 輸入欄位格式化與防呆

- 金額數值輸入欄位採用動態格式化機制，使用者輸入時即時顯示千分位及貨幣格式。

  ![動態格式化機制](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/dyn1.gif)

- 欄位輸入時即時檢查數值範圍，不符規則時即時提示錯誤。

  ![數值範圍檢核](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/chkrange.gif)

- 禁止非數字或不合法字元輸入，並於欄位下方顯示提示訊息。

  ![不合字元檢核](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/chk2.gif)


### 貼心輔助(輸入提示)

  ![輸入提示](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/info2.gif)


## 系統操作

### 1. 輸入押注金額
### 2. 點擊『押注』按鈕
### 3. 點擊『發牌』按鈕
### 4. 選擇牌桌上要換的牌，點擊『換牌』按鈕，替換成新牌。(只能換一次牌)
### 5. 點擊『判斷牌型』按鈕，即顯示對應的牌型結果及計算出賠率。
### 6. 關掉應用程式

### 系統操作畫面

　　![系統操作](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/runapp.gif)

## 系統功能及測試

### 案例1：秘技按鍵(『發牌』按鈕未啟用時)

| 按鍵 |    牌型    |
|------|------------|
|  q   | 皇家同花順 |
|  w   | 同花順     |
|  e   | 同花       |
|  r   | 四條(鐵支) |
|  t   | 葫蘆       |
|  y   | 三條       |
|  a   | 順子       |
|  s   | 兩對       |
|  d   | 一對       |

　![Case1](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/case1.gif)


### 案例2：破產時，選擇退出遊戲或重玩

　![Case2](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/case2.gif)

### 案例3：三條 (賠率3)

　![Case9](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/case9.gif)

### 案例4：兩對 (賠率2)

　![Case10](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/case10.gif)

### 案例5：一對 (賠率1)

　![Case11](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/case11.gif)

### 案例6：雜牌

　![Case12](https://github.com/tim9910/tim9910.github.io/blob/main/images/poker/case12.gif)
