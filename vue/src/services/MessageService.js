import axios from 'axios'

const path = '/quote';

export default{

    sendMessage(){
        return axios.post(path);
    }
}