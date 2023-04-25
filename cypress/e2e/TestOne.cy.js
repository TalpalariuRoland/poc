import HtmlPage from '../PageObj/HtmlPage'
describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/HtmlPage.html')
HtmlPage.selectCheckBox('1');
HtmlPage.selectRadioBox('3');
HtmlPage.typeInTextbox('Text');
HtmlPage.selectRadioBox('3');
HtmlPage.selectCheckBox('2');
HtmlPage.selectCheckBox('3');
HtmlPage.selectCheckBox('1');
  })
})
