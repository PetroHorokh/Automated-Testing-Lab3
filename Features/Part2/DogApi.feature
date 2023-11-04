Feature: DogAPI

Scenario: List all breeds
	When get all dog breeds
	Then validate status code

Scenario: Random image
	When get random image
	Then validate status code

Scenario Outline: Images by breed
	Given dog breed - <breed>
	When get images by breed
	Then validate status code

	Examples: 
	| breed |
	| boxer |
	| hound |

Scenario Outline: List of sub-breeds
	Given dog breed - <breed>
	When get list of sub-breed
	Then validate status code

	Examples: 
	| breed |
	| boxer |
	| hound |

Scenario Outline: Browse breed list
	Given dog breed - <breed>
	When get image of sub-breed
	Then validate status code

	Examples: 
	| breed    |
	| pug      |
	| pekinese |