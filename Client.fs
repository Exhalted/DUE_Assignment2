namespace Assignment2

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html

[<JavaScript>]
module Expenses =
    let income = Var.Create 0
    let expense = Var.Create 0

    let incomeInput = Var.Create 0
    let expenseInput = Var.Create 0

    let updateIncome (amount) = 
        income.Set(income.Value + amount)

    let updateExpense (amount) = 
        expense.Set(expense.Value + amount)

    [<SPAEntryPoint>]
    let Main () =
        div [] [
            h1 [] [text $"Current Income: %A{income.V}"]
            Doc.InputType.IntUnchecked [] incomeInput
            button [on.click (fun _ _ -> updateIncome incomeInput.Value)] [text "Update Income"]
            h1 [] [text $"Current Expenses: %A{expense.V}"]
            Doc.InputType.IntUnchecked [] expenseInput
            button [on.click (fun _ _ -> updateExpense expenseInput.Value)] [text "Update Expense"]
        ]
        |> Doc.RunById "main"