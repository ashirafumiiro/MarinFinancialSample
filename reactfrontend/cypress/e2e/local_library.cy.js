describe('empty spec', () => {
  it('start page shows counts', () => {
    cy.visit('http://localhost:3000/')
    cy.contains('Books')
    cy.contains('Authors')
  })

  it.only('can add book', () => {
    cy.visit('http://localhost:3000/books')
    cy.get('#add-book-button').click()
    cy.get('#Title').type('my test title')
    cy.get('#Summary').type('my test summary')
    cy.get('#Isbn').type('122336373736353')
    cy.get('#save-button').click()
  })
})