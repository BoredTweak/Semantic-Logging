import nltk
from nltk.corpus import treebank

#f = open('SemanticLogging-svc.runtime.log')
f = open('Small.log')
raw = f.read()
#raw = raw.replace('\n', ',')
sentences = raw.strip().split('----------')
print(sentences[0])
sentences = list(filter(None, sentences))
sentences = [sent.split('\n') for sent in sentences]
#sentences = [sent.split(':') for sent in sentences]
#sentences = nltk.sent_tokenize(sentences)
#sentences = [nltk.word_tokenize(sent) for sent in sentences]
#sentences = [nltk.pos_tag(sent) for sent in sentences] 
#print(sentences)
#print(sentences[0])

for x in sentences:
    print(x)
    

#toks = nltk.regexp_tokenize(text, sentence_re)

#grammar = "NP: {<DT>?<JJ>*<NN>}"
#cp = nltk.RegexpParser(grammar)
#print(sentences[1])
#result = cp.parse(sentences)

#result.draw()

# Bird, Steven, Edward Loper and Ewan Klein (2009), Natural Language Processing with Python. O’Reilly Media Inc.