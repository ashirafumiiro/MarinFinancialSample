import axios from 'axios'

const baseUrl = '/api/books'

const getAll = () => {
  const request = axios.get(baseUrl)
  return request.then(response => response.data)
}

const create = newObject => {
  const request = axios.post(baseUrl, newObject)
  return request.then(response => response.data)
}

const update = (id, newObject) => {
  const request = axios.put(`${baseUrl}/${id}`, newObject)
  return request.then(response => response.data)
}
const deleteBook = (id) => {
  const url = `${baseUrl}/${id}`
  const request = axios.delete(url)
  return request.then(response => response)
}

const bookService = { getAll, create, update, deleteBook }

export default bookService