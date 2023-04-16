import HtmlPage from '../PageObj/HtmlPObj'
describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/siteHtml.html')
HtmlPage.selectCheckBox(2);
HtmlPage.selectRadioBox(2);
HtmlPage.selectCheckBox(4);
HtmlPage.typeInTextbox('123123sfdas');
cy.wait(2000);
  })
})
