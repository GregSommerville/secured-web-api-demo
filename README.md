# Token-based Secured Web API Demonstration

## About this project
This project demonstrates a .NET Web API project that uses token-based security.  

It simulates a store that has an inventory.  Authorized users with a valid token can purchase an item, which will remove it from the inventory.

## API Description

This project contains two REST API endpoints - one for getting the current inventory, and one for making a purchase.  

As with any classic RESTful API, the endpoints are nouns - in this case, "Items" and "Purchase" 

### GET /api/items
This unauthenticated API endpoint will return a JSON array of items, with each item having a name, a description, and a price.

Example:

    GET /api/items

    Returns:
    [
        {
            "Name": "Hamburger",
            "Description": "A lovely medium rare burger",
            "Price": 9
        },
        {
            "Name": "Porter",
            "Description": "House Porter",
            "Price": 4
        },
        {
            "Name": "Stout",
            "Description": "House Stout",
            "Price": 4
        }
    ]

### POST /api/purchase/{itemName}
This API endpoint is available only to authenticated users (i.e., those with a valid token ID).

If the {itemName} isn't currently found in the inventory, a BadRequest error will be returned.

If the purchase succeeds, the item will be removed from the current inventory, and an object representing the new object will be returned, in classic REST style.

Example:

    POST /api/purchase/Ale

    Returns:
    {
        "Name": "Ale",
        "Description": "House Ale",
        "Price": 4
    }


## Security Approach
CORS, HTTPS requirement, token vs. other approaches

## Testing
The included web app
The unit tests and depend. injection