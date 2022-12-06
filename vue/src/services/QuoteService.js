import axios from 'axios';

const path = '/quote';

export default{

    getQuotes(){
        return axios.get(path);
    }
}