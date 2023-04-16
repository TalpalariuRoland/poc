import HtmlPage from '../PageObj/HtmlPObj'

describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/siteHtml.html')

    HtmlPage.selectCheckBox(1); //min 1 max 5 (automat -1 in array)
    HtmlPage.selectRadioBox(2); //min 1 max 5 (automat -1 in array)
    HtmlPage.typeInTextbox('Test');//input string
  })
})


// Can call both functions in any order
// as long as the numbers are in the range 
// of 1-5 , checkbox is not select, so can call
// for deselect too

//     npx cypress run --headed --spec "cypress/e2e/Html.cy.js"