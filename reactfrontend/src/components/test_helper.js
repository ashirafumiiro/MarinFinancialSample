
const initialAuthors = [
  {
    firstName: "Bova",
    lastName: "Ben",
    dateOfBirth: "1935-11-01T00:00:00",
    dateOfDeath: null,
    fullName: "Bova Ben",
    id: 1
  },
  {
    firstName: "Billings",
    lastName: "Bob",
    dateOfBirth: "1945-09-01T00:00:00",
    dateOfDeath: null,
    fullName: "Billings Bob",
    id: 2
  },
  {
    firstName: "Rothfuss",
    lastName: "Patric",
    dateOfBirth: "1973-06-06T00:00:00",
    dateOfDeath: null,
    fullName: "Rothfuss Patric",
    id: 3
  }
]

const initialGenres = [
  {
    name: "French Poetry",
    id: 2
  },
  {
    name: "Science Fiction",
    id: 3
  },
  {
    name: "Fantasy 2",
    id: 6
  }
]

const initialBooks = [
  {
    title: "Apes and Anges",
    summary: "Humankind headed out to the stars not for conquest, nor exploration, nor even for curiosity.",
    isbn: "9780765379528",
    authorId: 1,
    genreId: 3,
    author: {
      firstName: "Bova",
      lastName: "Ben",
      dateOfBirth: "1935-11-01T00:00:00",
      dateOfDeath: null,
      fullName: "Bova Ben",
      id: 1
    },
    genre: {
      name: "Science Fiction",
      id: 3
    },
    authorName: "Bova Ben",
    id: 1
  },
  {
    title: "Death Wave",
    summary: "In Ben Bova\u0027s previous novel New Earth, Jordan Kell led the first human mission beyond the solar system.",
    isbn: "9780765379504",
    authorId: 1,
    genreId: 3,
    author: {
      firstName: "Bova",
      lastName: "Ben",
      dateOfBirth: "1935-11-01T00:00:00",
      dateOfDeath: null,
      fullName: "Bova Ben",
      id: 1
    },
    genre: {
      name: "Science Fiction",
      id: 3
    },
    authorName: "Bova Ben",
    id: 2
  },
  {
    title: "Test",
    summary: "my summary",
    isbn: "43536727252452",
    authorId: 1,
    genreId: 2,
    author: {
      firstName: "Bova",
      lastName: "Ben",
      dateOfBirth: "1935-11-01T00:00:00",
      dateOfDeath: null,
      fullName: "Bova Ben",
      id: 1
    },
    genre: {
      name: "French Poetry",
      id: 2
    },
    authorName: "Bova Ben",
    id: 6
  }
]

const test_helper = { initialAuthors, initialBooks, initialGenres }
export default test_helper