import sys
import requests
import requests.exceptions

def main():
    GET_PUBLISHED_URL = 'https://medbaytech.herokuapp.com/api/feedback'
    TIMEOUT = 10

    try:
        response = requests.get(GET_PUBLISHED_URL, timeout = TIMEOUT)
    except:
        sys.exit(-1)

    try:
        response.raise_for_status()
    except HttpError:
        sys.exit(-1)

if __name__ == "__main__":
    main()